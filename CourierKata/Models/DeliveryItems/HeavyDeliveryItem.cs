
namespace CourierKata.Models.DeliveryItems
{
    internal class HeavyDeliveryItem : DeliveryItem
    {
        protected override int WeightLimitKilograms => 50;
        protected override int BaseCostCents => 5000;

        public override ParcelType Type => ParcelType.Heavy;

        public HeavyDeliveryItem(Parcel parcel) : base(parcel) { }
    }
}
