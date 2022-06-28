
namespace CourierKata.Models.DeliveryItems
{
    internal class MediumDeliveryItem : DeliveryItem
    {
        protected override int WeightLimitKilograms => 3;
        protected override int BaseCostCents => 800;

        public override ParcelType Type => ParcelType.Medium;

        public MediumDeliveryItem(Parcel parcel) : base(parcel) { }
    }
}
