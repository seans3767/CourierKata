using CourierKata.Models;
using CourierKata.Models.DeliveryItems;
using System.ComponentModel;

namespace CourierKata
{
    public static class DeliveryCostCalculator
    {
        public static DeliveryCostSummary CalculateCost(Parcel parcel)
        {
            ArgumentNullException.ThrowIfNull(parcel);

            var item = GetLowestCostDeliveryItemForParcel(parcel);

            var deliveryItems = new List<DeliveryItem>(1) { item };

            return new DeliveryCostSummary(deliveryItems);
        }

        public static DeliveryCostSummary CalculateCost(IEnumerable<Parcel> parcels)
        {
            ArgumentNullException.ThrowIfNull(parcels);

            var deliveryItems = parcels
                .Select(p => GetLowestCostDeliveryItemForParcel(p))
                .ToList();

            return new DeliveryCostSummary(deliveryItems);
        }

        private static DeliveryItem GetLowestCostDeliveryItemForParcel(Parcel parcel)
        {
            DeliveryItem lowestCostDeliveryItem = null;

            foreach (ParcelType type in Enum.GetValues(typeof(ParcelType)))
            {
                if (ParcelCouldBeType(parcel, type))
                {
                    var deliveryItem = DeliveryItemFactory.GetDeliveryItem(type, parcel);

                    if (lowestCostDeliveryItem == null ||
                        deliveryItem.TotalCostCents < lowestCostDeliveryItem.TotalCostCents)
                    {
                        lowestCostDeliveryItem = deliveryItem;
                    }
                }
            }

            return lowestCostDeliveryItem;
        }

        private static bool ParcelCouldBeType(Parcel parcel, ParcelType type)
        {
            var validator = ParcelTypeValidatorFactory.GetParcelTypeValidator(type);

            return validator.IsValid(parcel);
        }
    }
}