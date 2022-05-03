using Your_Money.Models;

namespace Your_Money.Providers
{
    public class ConsoleProvider
    {
        private User user;
        private MathCalculation calculation;
        
        public ConsoleProvider()
        {
            calculation = new MathCalculation();

            user = new User();

            user.controls.UserControlsNotify += Display;

            Parser.DisplayString = Display;
        }

        private void Display(string text)
        {
            Console.WriteLine(text);

            Thread.Sleep(2500);
        }

        private void DisplayTable<T>(List<T> entry) where T : Entry
        {
            if (entry.Count.Equals(0))
            {
                Console.WriteLine(Resurses.EmptyListExeption);

                return;
            }

            for (int counter = Resurses.CounterStartValue; counter < entry.Count; counter++)
            {
                Console.Write($"{counter} {entry[counter].Score} {entry[counter].Date} \t");

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private string? GetUserLine()
        {
            return Console.ReadLine();
        }

        public void SelectOperation(int cond,
             Func<Func<string>, double> doubleParser,
             Func<Func<string>, int> intParser)
        {
            switch (cond)
            {
                case (int)MenuOptions.AddIncomeEntry:
                    user.controls.AddIncomeEntry(doubleParser, GetUserLine, user.incomes);
                    break;

                case (int)MenuOptions.AddConsumptionEntry:
                    user.controls.AddConsumptionEntry(doubleParser, GetUserLine, user.consumptions);
                    break;

                case (int)MenuOptions.DelleteIncomeEntry:
                    user.controls.DelleteIncomeEntry(intParser, GetUserLine, user.incomes);
                    break;

                case (int)MenuOptions.DelleteConsumptionEntry:
                    user.controls.DelleteConsumptionEntry(intParser, GetUserLine, user.consumptions);
                    break;

                case (int)MenuOptions.ChangeIncomeEntry:
                    user.controls.ChangeIncomeEntry(intParser, doubleParser, GetUserLine, user.incomes);
                    break;

                case (int)MenuOptions.ChangeConsumptionEntry:
                    user.controls.ChangeConsumptionEntry(intParser, doubleParser, GetUserLine, user.consumptions);
                    break;

                case (int)MenuOptions.ShowIncomesTable:
                    DisplayTable(user.incomes);
                    break;

                case (int)MenuOptions.ShowConsumptionTable:
                    DisplayTable(user.consumptions);
                    break;

                case (int)MenuOptions.ShowArrive:
                    Display($"{Resurses.ArriveString} " +
                        $"{calculation.CalculateListSum(user.incomes) - calculation.CalculateListSum(user.consumptions)}");
                    break;

                case (int)MenuOptions.Exite:
                    break;

                default:
                    Display(Resurses.ExeprionString);
                    break;
            }
        }

        public void RunUserInterface()
        {
            var userCond = 0;

            do
            {
                Console.Clear();

                Display(Resurses.MenuString);

                userCond = Parser.ParseToIntId(GetUserLine);

                SelectOperation(userCond, Parser.ParseToDoubleSum, Parser.ParseToIntId);
            }
            while (userCond != (int)MenuOptions.Exite);
        }
    }
}