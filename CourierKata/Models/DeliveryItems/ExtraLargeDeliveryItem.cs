
namespace CourierKata.Models.DeliveryItems
{
    internal class ExtraLargeDeliveryItem : DeliveryItem
    {
        protected override int WeightLimitKilograms => 10;
        protected override int BaseCostCents => 2500;

        public override ParcelType Type => ParcelType.ExtraLarge;

        public ExtraLargeDeliveryItem(Parcel parcel) : base(parcel) { }
    }
}
