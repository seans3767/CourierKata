using CourierKata.Models.ParcelTypeValidators;
using System.ComponentModel;

namespace CourierKata
{
    internal static class ParcelTypeValidatorFactory
    {
        internal static ParcelTypeValidator GetParcelTypeValidator(ParcelType type)
        {
            return type switch
            {
                ParcelType.Small => new SmallParcelValidator(),
                ParcelType.Medium => new MediumParcelValidator(),
                ParcelType.Large => new LargeParcelValidator(),
                ParcelType.ExtraLarge => new ExtraLargeParcelValidator(),
                ParcelType.Heavy => new HeavyParcelValidator(),
                _ => throw new InvalidEnumArgumentException($"Unknown parcel type '{type}'.")
            };
        }
    }
}
