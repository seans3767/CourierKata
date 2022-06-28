
namespace CourierKata.Models.ParcelTypeValidators
{
    internal abstract class ParcelTypeValidator
    {
        protected abstract int? MaxDimensionInclusiveLowerBound { get; }
        protected abstract int? MaxDimensionExclusiveUpperBound { get; }

        internal bool IsValid(Parcel parcel)
        {
            ArgumentNullException.ThrowIfNull(parcel);

            var maxDimension = Math.Max(parcel.LengthCentimetres,
                Math.Max(parcel.WidthCentimetres, parcel.HeightCentimetres));

            var compliesWithLowerBound = !MaxDimensionInclusiveLowerBound.HasValue ||
                maxDimension >= MaxDimensionInclusiveLowerBound.Value;

            var compliesWithUpperBound = !MaxDimensionExclusiveUpperBound.HasValue ||
                maxDimension < MaxDimensionExclusiveUpperBound;

            return compliesWithLowerBound && compliesWithUpperBound;
        }
    }
}
