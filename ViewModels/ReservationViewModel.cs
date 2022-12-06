using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Market.Models.Items;
using Market.Commands;


namespace Market.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        public ReservationViewModel(ReservationData data, MarketSlot slot, Action<ReservationData> onChanged, Action<ReservationData> onDeleted)
        {
            this.data = data;
            this.slot = slot;

            this.onChanged = onChanged;
            this.onDeleted = onDeleted;

            ChangeStateCommand = new ActionCommand(ChangeState);

            stateName = stateNames[data.State];
            buttonName = buttonStateNames[data.State];
        }

        private readonly ReservationData data;
        private readonly MarketSlot slot;
        private readonly Action<ReservationData> onChanged;
        private readonly Action<ReservationData> onDeleted;
        private readonly Dictionary<ReservationData.States, string> stateNames = new Dictionary<ReservationData.States, string>()
        {
            {ReservationData.States.NotCall, "Not called yet" },
            {ReservationData.States.InProgress, "In Progress" },
            {ReservationData.States.Done, "Done" },
        };
        private readonly Dictionary<ReservationData.States, string> buttonStateNames = new Dictionary<ReservationData.States, string>()
        {
            {ReservationData.States.NotCall, "Make in progress" },
            {ReservationData.States.InProgress, "Make done" },
            {ReservationData.States.Done, "Remove" },
        };


        private string stateName;
        private string buttonName;

        public string Name
        {
            get => data.Name;
        }
        public string Surname
        {
            get => data.Surname;
        }
        public string Model
        {
            get => slot.Item.Model;
        }
        public string Brand
        {
            get => slot.Item.Brand;
        }
        public long Phone
        {
            get => data.Phone;
        }
        public DateTime Date
        {
            get => data.DateTime;
            set
            {

            }
        }
        public string State
        {
            get => stateName;
            set
            {
                stateName = value;
                OnPropertyChanged(State);
            }
        }
        public string ButtonText
        {
            get => buttonName;
            set
            {
                buttonName = value;
                OnPropertyChanged(ButtonText);
            }
        }

        public ICommand ChangeStateCommand { get; }


        private void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Order delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch(result)
            {
                case MessageBoxResult.Yes:
                    onDeleted?.Invoke(data);
                    break;
            }

        }
        private void ChangeState()
        {
            switch(data.State)
            {
                case ReservationData.States.NotCall:
                    data.State = ReservationData.States.InProgress;
                    State = stateNames[data.State];
                    ButtonText = buttonStateNames[data.State];

                    onChanged?.Invoke(data);
                    break;
                case ReservationData.States.InProgress:
                    data.State = ReservationData.States.Done;
                    State = stateNames[data.State];
                    ButtonText = buttonStateNames[data.State];

                    onChanged?.Invoke(data);
                    break;
                case ReservationData.States.Done:
                    Delete();
                    break;
            }
        }
    }
}
