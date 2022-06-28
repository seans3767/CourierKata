
namespace CourierKata.Models
{
    public class Parcel
    {
        public ParcelSize Size { get; private set; }

        public Parcel(int lengthCentimetres, int widthCentimetres, int heightCentimetres)
        {
            if (lengthCentimetres <= 0) throw new ArgumentOutOfRangeException(nameof(lengthCentimetres));
            if (widthCentimetres <= 0) throw new ArgumentOutOfRangeException(nameof(widthCentimetres));
            if (heightCentimetres <= 0) throw new ArgumentOutOfRangeException(nameof(heightCentimetres));

            Size = GetSizeForDimensions(lengthCentimetres, widthCentimetres, heightCentimetres);
        }

        private static ParcelSize GetSizeForDimensions(int lengthCentimetres, int widthCentimetres, int heightCentimetres)
        {
            var maxDimension = Math.Max(lengthCentimetres, Math.Max(widthCentimetres, heightCentimetres));

            var size = maxDimension switch
            {
                < 10 => ParcelSize.Small,
                >= 10 and < 50 => ParcelSize.Medium,
                >= 50 and < 100 => ParcelSize.Large,
                _ => ParcelSize.ExtraLarge
            };

            return size;
        }
    }
}
