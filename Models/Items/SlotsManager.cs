using Market.Models.Data;
using System.Collections.Generic;
using Market.Models.Users;
using System.Linq;
using System;

namespace Market.Models.Items
{
    public class SlotsManager
    {
        public SlotsManager(IMarketDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        private readonly IMarketDataBase dataBase;

        public List<MarketSlot> Slots
        {
            get => dataBase.GetAllSlots();
        }
        public List<ReservationData> Reservations
        {
            get => dataBase.GetAllReservations();
        }

        public event Action OnMarketItemsListChanged;
        public event Action OnReservationItemsListChanged;

        public void CreateNewSlot(MarketItem item, ItemCost cost, int count)
        {
            MarketSlot slot = new MarketSlot(-1, item, cost, count);

            dataBase.AddSlot(slot);
        }
        public void OverrideSlot(MarketSlot slot)
        {
            dataBase.ChangeSlot(slot.id, slot);
        }
        public void DeleteSlot(MarketSlot slot)
        {
            dataBase.RemoveSlot(slot.id);

            Reservations.Where(x => x.SlotId == slot.id).ToList().ForEach(x => dataBase.DeleteReservation(x.Id));

            OnMarketItemsListChanged?.Invoke();
        }


        public void MakeSlotReservation(ReservationData data)
        {
            dataBase.MakeReservation(data);
        }
        public void OverrideReservation(ReservationData data)
        {
            dataBase.OverrideReservation(data);
            if(data.State == ReservationData.States.Done)
            {
                MarketSlot slot = Slots.First(x => x.id == data.SlotId);
                slot.Count--;
                OverrideSlot(slot);
            }

            OnReservationItemsListChanged?.Invoke();
        }
        public void DeleteReservation(ReservationData data)
        {
            dataBase.DeleteReservation(data.Id);

            OnReservationItemsListChanged?.Invoke();
        }
    }
}
