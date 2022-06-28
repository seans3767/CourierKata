
namespace CourierKata.Models.DeliveryItems
{
    public abstract class DeliveryItem
    {
        private const int ExcessWeightCostCentsPerKilogram = 200;

        protected abstract int BaseCostCents { get; }
        protected abstract int WeightLimitKilograms { get; }

        public abstract ParcelType Type { get; }
        public Parcel Parcel { get; private set; }
        public int ExcessWeightKilograms => GetExcessWeightKilograms();
        public int ExcessWeightCostCents => ExcessWeightKilograms * ExcessWeightCostCentsPerKilogram;
        public int TotalCostCents => BaseCostCents + ExcessWeightCostCents;

        public DeliveryItem(Parcel parcel)
        {
            ArgumentNullException.ThrowIfNull(parcel);

            this.Parcel = parcel;
        }

        private int GetExcessWeightKilograms()
        {
            var weightDifference = this.Parcel.WeightKilograms - WeightLimitKilograms;

            return Math.Max(weightDifference, 0);
        }
    }
}
