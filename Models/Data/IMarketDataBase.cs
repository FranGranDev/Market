using Market.Models.Items;
using System.Collections.Generic;


namespace Market.Models.Data
{
    public interface IMarketDataBase
    {
        void AddSlot(MarketSlot item);
        void RemoveSlot(int id);

        MarketSlot GetSlot(int id);
        void ChangeSlot(int id, MarketSlot newItem);
        List<MarketSlot> GetAllSlots();


        void MakeReservation(ReservationData data);
        void OverrideReservation(ReservationData data);
        void DeleteReservation(int id);
        List<ReservationData> GetAllReservations();
       
    }
}
