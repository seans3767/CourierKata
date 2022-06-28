
namespace CourierKata.Models.ParcelTypeValidators
{
    internal class LargeParcelValidator : ParcelTypeValidator
    {
        protected override int? MaxDimensionInclusiveLowerBound => 50;
        protected override int? MaxDimensionExclusiveUpperBound => 100;
    }
}
