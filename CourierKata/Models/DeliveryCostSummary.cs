
namespace CourierKata.Models
{
    public class DeliveryCostSummary
    {
        public IList<ParcelCost> ParcelCosts { get; private set; }
        public int TotalCostPence { get; private set; }

        public DeliveryCostSummary(IList<ParcelCost> parcelCosts)
        {
            ArgumentNullException.ThrowIfNull(parcelCosts);
            ParcelCosts = parcelCosts;
            TotalCostPence = parcelCosts.Sum(pc => pc.CostPence);
        }
    }
}
