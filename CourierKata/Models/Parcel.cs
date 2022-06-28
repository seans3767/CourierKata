
namespace CourierKata.Models
{
    public class Parcel
    {
        public int LengthCentimetres { get; private set; }
        public int WidthCentimetres { get; private set; }
        public int HeightCentimetres { get; private set; }
        public int WeightKilograms { get; private set; }
        public Parcel(int lengthCentimetres, int widthCentimetres, int heightCentimetres, int weightKilograms)
        {
            if (lengthCentimetres <= 0) throw new ArgumentOutOfRangeException(nameof(lengthCentimetres));
            if (widthCentimetres <= 0) throw new ArgumentOutOfRangeException(nameof(widthCentimetres));
            if (heightCentimetres <= 0) throw new ArgumentOutOfRangeException(nameof(heightCentimetres));
            if (weightKilograms <= 0) throw new ArgumentOutOfRangeException(nameof(weightKilograms));

            LengthCentimetres = lengthCentimetres;
            WidthCentimetres= widthCentimetres;
            HeightCentimetres = heightCentimetres;
            WeightKilograms = weightKilograms;
        }
    }
}
