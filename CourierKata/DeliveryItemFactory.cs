using CourierKata.Models;
using CourierKata.Models.DeliveryItems;
using System.ComponentModel;

namespace CourierKata
{
    internal static class DeliveryItemFactory
    {
        internal static DeliveryItem GetDeliveryItem(ParcelType type, Parcel parcel)
        {
            return type switch
            {
                ParcelType.Small => new SmallDeliveryItem(parcel),
                ParcelType.Medium => new MediumDeliveryItem(parcel),
                ParcelType.Large => new LargeDeliveryItem(parcel),
                ParcelType.ExtraLarge => new ExtraLargeDeliveryItem(parcel),
                ParcelType.Heavy => new HeavyDeliveryItem(parcel),
                _ => throw new InvalidEnumArgumentException($"Unknown parcel type '{type}'.")
            };
        }
    }
}
