namespace Market.Models.Items
{
    public class ReservationData
    {
        public ReservationData(string name, string surname, string phone)
        {
            this.name = name;
            this.surname = surname;
            this.phone = phone;
        }

        private string name;
        private string surname;
        private string phone;


        public string Name => name;
        public string Surname => surname;
        public string Phone => phone;
    }
}
