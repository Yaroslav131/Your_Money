using System.ComponentModel.DataAnnotations;

namespace Your_Money
{
    public abstract class Entry
    {
        public int Id { get; set; }
        public double Score { get; set; }
        public DateTime Date { get; set; }

        public Entry(double money, DateTime date)
        {
            Score = money;
            Date = date;
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Score<0)
                errors.Add(new ValidationResult("Number under zero"));

            return errors;
        }
    }
}
