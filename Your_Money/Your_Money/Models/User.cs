namespace Your_Money.Models
{
    public class User
    {
        public UserControls controls { get; set; }
        public List<IncomeEntry> incomes { get; set; }
        public List<ConsumptionEntry> consumptions { get; set; }
        public double Arrive { get; set; }

        public User()
        {
            incomes = new List<IncomeEntry>();
            consumptions = new List<ConsumptionEntry>();
            controls = new UserControls();
        }
    }
}
