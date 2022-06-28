
namespace CourierKata.Models
{
    public class ParcelCost
    {
        public Parcel Parcel { get; set; }
        public int BaseSizeCostPence { get; set; }
        public int ExcessWeightCostPence { get; set; }
        public int TotalCostPence => BaseSizeCostPence + ExcessWeightCostPence;
    }
}
