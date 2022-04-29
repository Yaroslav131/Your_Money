using System.ComponentModel.DataAnnotations;

namespace Your_Money.Models
{
    public class UserControls
    {
        public void AddIncomeEntry(Func<Func<string>, double> doubleParser, Func<string> getSting, List<Income> incomes)
        {
            var money = doubleParser(getSting);
            var income = new Income(money, DateTime.Now);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(income);

            if (!Validator.TryValidateObject(income, context, results, true))
            {
                foreach (var error in results)
                {
                    //event Console.WriteLine(error.ErrorMessage);
                }
            }
            else
            {
                incomes.Add(income);
            }
        }

        //private void AddConsumptionEntry(Func<Func<string>, Predicate<double>, double> doubleParser, Func<string> getSting)
        //{
        //    displayText?.Invoke(Resurses.InvateWriteMoneyString);

        //    var money = doubleParser(getSting, (x) => x >= 0);

        //    consumptions.Add(new Consumption(money, DateTime.Now));

        //    Notify?.Invoke(Resurses.SeccusessOpetationStr);
        //}

        //private void DelleteIncomeEntry(Func<Func<string>, int> intParser,
        //    Func<string> getSting, Predicate<int> inListRange, Predicate<List<Income>> isEmptyList)
        //{
        //    if (isEmptyList(incomes))
        //    {
        //        Notify?.Invoke(Resurses.EmptyListExeption);

        //        return;
        //    }

        //    displayText?.Invoke(Resurses.InvateWriteIdString);

        //    var entry = incomes.Find(x=>x.Id.Equals(intParser(getSting)));

        //    if (entry.Equals(null))
        //    {
        //        Notify?.Invoke(Resurses.ExeprionString);

        //        return;
        //    }

        //    incomes.Remove(entry);

        //    Notify?.Invoke(Resurses.SeccusessOpetationStr);
        //}

        //private void DelleteConsumptionEntry(Func<Func<string>, int> intParser,
        //    Func<string> getSting, Predicate<int> inListRange, Predicate<List<Consumption>> isEmptyList)
        //{
        //    if (isEmptyList(consumptions))
        //    {
        //        Notify?.Invoke(Resurses.EmptyListExeption);

        //        return;
        //    }

        //    displayText?.Invoke(Resurses.InvateWriteIdString);

        //    var entry = consumptions.Find(x => x.Id.Equals(intParser(getSting)));

        //    if (entry.Equals(null))
        //    {
        //        Notify?.Invoke(Resurses.ExeprionString);

        //        return;
        //    }

        //    consumptions.Remove(entry);

        //    Notify?.Invoke(Resurses.SeccusessOpetationStr);
        //}

        //private void ChangeIncomeEntry(Func<Func<string>, int> intParser, Func<Func<string>, Predicate<double>, double> doubleParser,
        //    Func<string> getSting, Predicate<int> inListRange, Predicate<List<Income>> isEmptyList)
        //{
        //    if (isEmptyList(incomes))
        //    {
        //        Notify?.Invoke(Resurses.EmptyListExeption);

        //        return;
        //    }

        //    displayText?.Invoke(Resurses.InvateWriteIdString);

        //    var entryId = intParser(getSting);

        //    displayText?.Invoke(Resurses.InvateWriteMoneyString);

        //    var money = doubleParser(getSting, (x) => x >= 0);

        //    var entry = incomes.Find(x => x.Id.Equals(intParser(getSting)));

        //    if (entry.Equals(null))
        //    {
        //        Notify?.Invoke(Resurses.ExeprionString);

        //        return;
        //    }

        //    incomes[entryId]=new Income(money, DateTime.Now);

        //    Notify?.Invoke(Resurses.SeccusessOpetationStr);
        //}

        //private void ChangeConsumptionEntry(Func<Func<string>, int> intParser, Func<Func<string>, Predicate<double>, double> doubleParser,
        //    Func<string> getSting, Predicate<int> inListRange, Predicate<List<Consumption>> isEmptyList)
        //{
        //    if (isEmptyList(consumptions))
        //    {
        //        Notify?.Invoke(Resurses.EmptyListExeption);

        //        return;
        //    }

        //    displayText?.Invoke(Resurses.InvateWriteIdString);

        //    var entryId = intParser(getSting);

        //    displayText?.Invoke(Resurses.InvateWriteMoneyString);

        //    var money = doubleParser(getSting, (x) => x >= 0);

        //    var entry = incomes.Find(x => x.Id.Equals(intParser(getSting)));

        //    if (entry.Equals(null))
        //    {
        //        Notify?.Invoke(Resurses.ExeprionString);

        //        return;
        //    }

        //    incomes[entryId] = new Income(money, DateTime.Now);

        //    Notify?.Invoke(Resurses.SeccusessOpetationStr);
        //}

        //private  double CalculateArrive()
        //{
        //    foreach (Income entry in incomes)
        //    {
        //        Arrive += entry.Score;
        //    }

        //    foreach (Consumption entry in consumptions)
        //    {
        //        Arrive -= entry.Score;
        //    }

        //    return Arrive;
        //}

        //private void Exite()
        //{
        //    Environment.Exit(0);
        //}

        //public void SelectOperation(int cond, Action<List<Entry>, Predicate<List<Entry>>> outPutTable,
        //    Action<string> outPutArrive,Func<Func<string>, Predicate<double>, double> doubleParser,
        //    Func<Func<string>, int> intParser, Func<string> getUserString)
        //{
        //    switch (cond)
        //    {
        //        case (int)MenuOptions.AddIncomeEntry:
        //            AddIncomeEntry(doubleParser, getUserString);
        //            break;

        //        case (int)MenuOptions.AddConsumptionEntry:
        //            AddConsumptionEntry(doubleParser, getUserString);
        //            break;

        //        case (int)MenuOptions.DelleteIncomeEntry:
        //            DelleteIncomeEntry(intParser, getUserString, 
        //                (x) => x >= 0 && x < incomes.Count, (x) => x.Count.Equals(0));
        //            break;

        //        case (int)MenuOptions.DelleteConsumptionEntry:
        //            DelleteConsumptionEntry(intParser, getUserString, 
        //                (x) => x >= 0 && x < consumptions.Count, (x) => x.Count.Equals(0));
        //            break;

        //        case (int)MenuOptions.ChangeIncomeEntry:
        //            ChangeIncomeEntry(intParser, doubleParser, getUserString, 
        //                (x) => x >= 0 && x < incomes.Count, (x) => x.Count.Equals(0));
        //            break;

        //        case (int)MenuOptions.ChangeConsumptionEntry:
        //            ChangeConsumptionEntry(intParser, doubleParser, getUserString, 
        //                (x) => x >= 0 && x < consumptions.Count, (x) => x.Count.Equals(0));
        //            break;

        //        case (int)MenuOptions.ShowIncomesTable:
        //            outPutTable(incomes.Cast<Entry>().ToList(),(x)=>incomes.Count==0);
        //            break;

        //        case (int)MenuOptions.ShowConsumptionTable:
        //            outPutTable(consumptions.Cast<Entry>().ToList(), (x) => incomes.Count == 0);
        //            break;

        //        case (int)MenuOptions.ShowArrive:
        //            outPutArrive($"{Resurses.ArriveString} {CalculateArrive()}");
        //            break;

        //        case (int)MenuOptions.Exite:
        //            Exite();
        //            break;

        //        default:
        //            Notify?.Invoke(Resurses.ExeprionString);
        //            break;
        //    }
        //}
    }
}