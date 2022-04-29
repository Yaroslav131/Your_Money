namespace Your_Money
{
    public class MathCalculation   
    {
        public double CalculateListSum<Q>(List<Q> entrys)
            where Q : Entry
        {
            var sum = 0.0;

            foreach (Q entry in entrys)
            {
                 sum += entry.Score;
            }

            return sum;
        }
    }
}
