namespace Your_Money.Models
{
    public class User
    {
        private UserControls controls;
        private List<Income> incomes;
        private List<Consumption> consumptions;
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