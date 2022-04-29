namespace Your_Money.Models
{
    public class User
    {
        public UserControls controls { get; set; }
        public List<Income> incomes { get; set; }
        public List<Consumption> consumptions { get; set; }
        public double Arrive { get; set; }

        public User()
        {
            Arrive = 0;
            incomes = new List<Income>();
            consumptions = new List<Consumption>();
            controls = new UserControls();
        }
    }
}