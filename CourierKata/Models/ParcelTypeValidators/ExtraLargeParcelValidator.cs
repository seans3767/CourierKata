
namespace CourierKata.Models.ParcelTypeValidators
{
    internal class ExtraLargeParcelValidator : ParcelTypeValidator
    {
        protected override int? MaxDimensionInclusiveLowerBound => 100;
        protected override int? MaxDimensionExclusiveUpperBound => null;
    }
}
