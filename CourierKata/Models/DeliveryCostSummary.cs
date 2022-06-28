using CourierKata.Models.DeliveryItems;

namespace CourierKata.Models
{
    public class DeliveryCostSummary
    {
        public IList<DeliveryItem> DeliveryItems { get; private set; }
        public int TotalCostCents { get; private set; }
        public int SpeedyShippingCostCents { get; private set; }

        public DeliveryCostSummary(IList<DeliveryItem> deliveryItems)
        {
            ArgumentNullException.ThrowIfNull(deliveryItems);
            DeliveryItems = deliveryItems;
            TotalCostCents = deliveryItems.Sum(pc => pc.TotalCostCents);
            SpeedyShippingCostCents = TotalCostCents * 2;
        }
    }
}
