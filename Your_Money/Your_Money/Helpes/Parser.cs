namespace Your_Money
{
    public static class Parser
    {
        public delegate void ParserHandler(string info);
        public static ParserHandler? DisplayString;

        public static int ParseToIntId(Func<string> getString)
        {
            int resoult;

            DisplayString?.Invoke(Resurses.InvateWriteIdString);

            while (!int.TryParse(getString(), out resoult))
            {
                DisplayString?.Invoke(Resurses.ExeprionString);
            }

            return resoult - 1;
        }

        public static double ParseToDoubleSum(Func<string> getString)
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
