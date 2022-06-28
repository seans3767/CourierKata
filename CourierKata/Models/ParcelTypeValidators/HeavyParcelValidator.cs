
namespace CourierKata.Models.ParcelTypeValidators
{
    internal class HeavyParcelValidator : ParcelTypeValidator
    {
        protected override int? MaxDimensionInclusiveLowerBound => null;
        protected override int? MaxDimensionExclusiveUpperBound => null;
    }
}
