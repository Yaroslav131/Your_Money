namespace Your_Money
{
    public class Parser
    {
        public delegate void ParserHandler(string info);
        public ParserHandler? DisplayString;

        public int ParseToIntId(Func<string> getString)
        {
            int resoult;

            DisplayString?.Invoke(Resurses.InvateWriteIdString);

            while (!int.TryParse(getString(), out resoult))
            {
                DisplayString?.Invoke(Resurses.ExeprionString);
            }

            return resoult - 1;
        }

        public double ParseToDoubleSum(Func<string> getString)
        {
            double resoult;

            DisplayString?.Invoke(Resurses.InvateWriteMoneyString);

            while (!(double.TryParse(getString(), out resoult)))
            {
                DisplayString?.Invoke(Resurses.ExeprionString);
            }

            return resoult;
        }
    }
}