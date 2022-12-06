using System;

namespace Market.Models.Items
{
    public class ReservationData
    {
        public ReservationData(int id, int slotId, string login, string name, string surname, long phone, DateTime dateTime, States state)
        {
            this.id = id;
            this.slotId = slotId;
            this.login = login;
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.dateTime = dateTime;
            this.state = state;
        }
        public ReservationData(int slotId, string login, string name, string surname, long phone)
        {
            this.slotId = slotId;
            this.login = login;
            this.name = name;
            this.surname = surname;
            this.phone = phone;

            dateTime = DateTime.Now;
            state = States.NotCall;
        }

        private int id;
        private int slotId;
        private string login;
        private string name;
        private string surname;
        private long phone;
        private DateTime dateTime;
        private States state;


        public int Id => id;
        public int SlotId => slotId;
        public string Login => login;
        public string Name => name;
        public string Surname => surname;
        public string FullName => $"{Name} {Surname}";
        public long Phone => phone;
        public DateTime DateTime => dateTime;
        public States State
        {
            get => state;
            set => state = value;
        }


        public enum States
        {
            NotCall,
            InProgress,
            Done,
        }
    }
}
