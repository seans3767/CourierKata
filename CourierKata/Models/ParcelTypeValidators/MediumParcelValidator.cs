
namespace CourierKata.Models.ParcelTypeValidators
{
    internal class MediumParcelValidator : ParcelTypeValidator
    {
        protected override int? MaxDimensionInclusiveLowerBound => 10;
        protected override int? MaxDimensionExclusiveUpperBound => 50;
    }
}
