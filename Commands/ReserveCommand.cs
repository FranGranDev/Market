using System;
using Market.Models.Items;
using Market.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Commands
{
    public class ReserveCommand : CommandBase
    {
        public ReserveCommand(ReservationViewModel reservationViewModel, MarketSlot marketSlot)
        {
            this.marketSlot = marketSlot;
            this.reservationViewModel = reservationViewModel;
        }

        private readonly MarketSlot marketSlot;
        private readonly ReservationViewModel reservationViewModel;

        public override void Execute(object parameter)
        {
            
        }
    }
}
