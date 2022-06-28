
namespace CourierKata.Models.ParcelTypeValidators
{
    internal class SmallParcelValidator : ParcelTypeValidator
    {
        protected override int? MaxDimensionInclusiveLowerBound => null;
        protected override int? MaxDimensionExclusiveUpperBound => 10;
    }
}
