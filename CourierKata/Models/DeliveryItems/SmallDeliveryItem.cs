
namespace CourierKata.Models.DeliveryItems
{
    internal class SmallDeliveryItem : DeliveryItem
    {
        protected override int WeightLimitKilograms => 1;
        protected override int BaseCostCents => 300;

        public override ParcelType Type => ParcelType.Small;

        public SmallDeliveryItem(Parcel parcel) : base(parcel) { }
    }
}
