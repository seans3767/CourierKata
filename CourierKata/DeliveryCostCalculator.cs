using CourierKata.Models;
using System.ComponentModel;

namespace CourierKata
{
    public static class DeliveryCostCalculator
    {
        private const int SmallParcelCostPence = 300;
        private const int MediumParcelCostPence = 800;
        private const int LargeParcelCostPence = 1500;
        private const int ExtraLargeParcelCostPence = 2500;

        public static DeliveryCostSummary CalculateCost(Parcel parcel)
        {
            ArgumentNullException.ThrowIfNull(parcel);

            var cost = GetParcelCost(parcel);

            var parcelCosts = new List<ParcelCost>(1) { cost };

            return new DeliveryCostSummary(parcelCosts);
        }

        public static DeliveryCostSummary CalculateCost(IEnumerable<Parcel> parcels)
        {
            ArgumentNullException.ThrowIfNull(parcels);

            var parcelCosts = parcels
                .Select(p => GetParcelCost(p))
                .ToList();

            return new DeliveryCostSummary(parcelCosts);
        }

        private static ParcelCost GetParcelCost(Parcel parcel)
        {
            var costPence = GetParcelCostPenceForSize(parcel.Size);

            return new ParcelCost()
            {
                Parcel = parcel,
                CostPence = costPence
            };
        }

        private static int GetParcelCostPenceForSize(ParcelSize size)
        {
            return size switch
            {
                ParcelSize.Small => SmallParcelCostPence,
                ParcelSize.Medium => MediumParcelCostPence,
                ParcelSize.Large => LargeParcelCostPence,
                ParcelSize.ExtraLarge => ExtraLargeParcelCostPence,
                _ => throw new InvalidEnumArgumentException($"Unknown parcel size '{size}'.")
            };
        }
    }
}