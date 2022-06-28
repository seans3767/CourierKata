
namespace CourierKata.Models.DeliveryItems
{
    internal class LargeDeliveryItem : DeliveryItem
    {
        protected override int WeightLimitKilograms => 6;
        protected override int BaseCostCents => 1500;

        public override ParcelType Type => ParcelType.Large;

        public LargeDeliveryItem(Parcel parcel) : base(parcel) { }
    }
}
