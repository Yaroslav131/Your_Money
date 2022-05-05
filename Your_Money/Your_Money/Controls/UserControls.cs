using System.ComponentModel.DataAnnotations;

namespace Your_Money.Models
{
    public class UserControls
    {
        public delegate void UserControlsHendler(string text);
        public event UserControlsHendler? UserControlsNotify;

        public void AddIncomeEntry(Func<Func<string>, double> doubleParser, 
            Func<string> getSting,List<IncomeEntry> incomes)
        {
            var money = doubleParser(getSting);
            var income = new IncomeEntry(money, DateTime.Now);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(income);

            if (!Validator.TryValidateObject(income, context, results, true))
            {
                foreach (var error in results)
                {
                    UserControlsNotify?.Invoke(error.ErrorMessage);
                }
            }
            else
            {
                incomes.Add(income);

                UserControlsNotify?.Invoke(Resurses.SeccusessOpetationStr);
            }
        }

        public void AddConsumptionEntry(Func<Func<string>, double> doubleParser, 
            Func<string> getSting, List<ConsumptionEntry> consumptions)
        {
            var money = doubleParser(getSting);
            var consumption = new ConsumptionEntry(money, DateTime.Now);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(consumption);

            if (!Validator.TryValidateObject(consumption, context, results, true))
            {
                foreach (var error in results)
                {
                    UserControlsNotify?.Invoke(error.ErrorMessage);
                }
            }
            else
            {
                consumptions.Add(consumption);

                UserControlsNotify?.Invoke(Resurses.SeccusessOpetationStr);
            }
        }

        public void DelleteIncomeEntry(Func<Func<string>, int> intParser,
            Func<string> getSting, List<IncomeEntry> incomes)
        {
            if (incomes.Count.Equals(0))
            {
                UserControlsNotify?.Invoke(Resurses.EmptyListExeption);

                return;
            }

            var entry = incomes.Find(x => x.Id.Equals(intParser(getSting)));

            if (entry.Equals(null))
            {
                UserControlsNotify?.Invoke(Resurses.ExeprionString);

                return;
            }

            incomes.Remove(entry);

            UserControlsNotify?.Invoke(Resurses.SeccusessOpetationStr);
        }

        public void DelleteConsumptionEntry(Func<Func<string>, int> intParser,
            Func<string> getSting, List<ConsumptionEntry> consumptions)
        {
            if (consumptions.Count.Equals(0))
            {
                UserControlsNotify?.Invoke(Resurses.EmptyListExeption);

                return;
            }

            var entry = consumptions.Find(x => x.Id.Equals(intParser(getSting)));

            if (entry.Equals(null))
            {
                UserControlsNotify?.Invoke(Resurses.ExeprionString);

                return;
            }

            consumptions.Remove(entry);

            UserControlsNotify?.Invoke(Resurses.SeccusessOpetationStr);
        }

        public void ChangeIncomeEntry(Func<Func<string>, int> intParser, Func<Func<string>, double> doubleParser,
            Func<string> getSting, List<IncomeEntry> incomes)
        {
            if (incomes.Count.Equals(0))
            {
                UserControlsNotify?.Invoke(Resurses.EmptyListExeption);

                return;
            }

            var entryId = intParser(getSting);

            var money = doubleParser(getSting);

            var entry = incomes.Find(x => x.Id.Equals(entryId));

            if (entry.Equals(null))
            {
                UserControlsNotify?.Invoke(Resurses.ExeprionString);

                return;
            }

            incomes[entryId] = new IncomeEntry(money, DateTime.Now);

            UserControlsNotify?.Invoke(Resurses.SeccusessOpetationStr);
        }

        public void ChangeConsumptionEntry(Func<Func<string>, int> intParser, Func<Func<string>, double> doubleParser,
            Func<string> getSting, List<ConsumptionEntry> consumptions)
        {
            if (consumptions.Count.Equals(0))
            {
                UserControlsNotify?.Invoke(Resurses.EmptyListExeption);

                return;
            }

            var entryId = intParser(getSting);

            var money = doubleParser(getSting);

            var entry = consumptions.Find(x => x.Id.Equals(entryId));

            if (entry.Equals(null))
            {
                UserControlsNotify?.Invoke(Resurses.ExeprionString);

                return;
            }

            consumptions[entryId] = new ConsumptionEntry(money, DateTime.Now);

            UserControlsNotify?.Invoke(Resurses.SeccusessOpetationStr);
        }
    }
}
