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

        private const int SmallParcelWeightLimitKilograms = 1;
        private const int MediumParcelWeightLimitKilograms = 3;
        private const int LargeParcelWeightLimitKilograms = 6;
        private const int ExtraLargeParcelWeightLimitKilograms = 10;

        private const int ExcessWeightCostPencePerKilogram = 200;

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

            var parcelCost = new ParcelCost()
            {
                Parcel = parcel,
                BaseSizeCostPence = costPence
            };

            var excessWeightKilograms = ExcessWeightKilograms(parcel);

            if (excessWeightKilograms.HasValue)
            {
                parcelCost.ExcessWeightCostPence = excessWeightKilograms.Value * ExcessWeightCostPencePerKilogram;
            }

            return parcelCost;
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

        private static int? ExcessWeightKilograms(Parcel parcel)
        {
            var weightDifference = parcel.Size switch
            {
                ParcelSize.Small => parcel.WeightKilograms - SmallParcelWeightLimitKilograms,
                ParcelSize.Medium => parcel.WeightKilograms - MediumParcelWeightLimitKilograms,
                ParcelSize.Large => parcel.WeightKilograms - LargeParcelWeightLimitKilograms,
                ParcelSize.ExtraLarge => parcel.WeightKilograms - ExtraLargeParcelWeightLimitKilograms,
                _ => throw new InvalidEnumArgumentException($"Unknown parcel size '{parcel.Size}'.")
            };

            return weightDifference > 0 ? weightDifference : null;
        }
    }
}