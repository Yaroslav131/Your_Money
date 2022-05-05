using System.ComponentModel.DataAnnotations;

namespace Your_Money
{
    public abstract class Entry
    {
        public int Id { get; set; }
        [Range(Resurses.MinValueOfScore, Resurses.MaxValueOfScore)]
        public double Score { get; set; }
        public DateTime Date { get; set; }

        public Entry(double money, DateTime date)
        {
            Score = money;
            Date = date;
        }
    }
}
