using CourierKata.Models;
using System;
using Xunit;

namespace CourierKata.Tests
{
    public class ParcelTests
    {
        [Fact]
        public void SmallDimesionsLowerLimitGiveSmallSize()
        {
            var parcel = new Parcel(1, 1, 1, 1);
            Assert.Equal(ParcelSize.Small, parcel.Size);
        }

        [Fact]
        public void SmallDimesionsUpperLimitGiveSmallSize()
        {
            var parcel = new Parcel(9, 9, 9, 1);
            Assert.Equal(ParcelSize.Small, parcel.Size);
        }

        [Fact]
        public void MediumDimesionsLowerLimitGiveMediumSize()
        {
            var parcel = new Parcel(10, 10, 10, 1);
            Assert.Equal(ParcelSize.Medium, parcel.Size);
        }

        [Fact]
        public void MediumDimesionsUpperLimitGiveMediumSize()
        {
            var parcel = new Parcel(49, 49, 49, 1);
            Assert.Equal(ParcelSize.Medium, parcel.Size);
        }

        [Fact]
        public void LargeDimesionsLowerLimitGiveLargeSize()
        {
            var parcel = new Parcel(50, 50, 50, 1);
            Assert.Equal(ParcelSize.Large, parcel.Size);
        }

        [Fact]
        public void LargeDimesionsUpperLimitGiveLargeSize()
        {
            var parcel = new Parcel(99, 99, 99, 1);
            Assert.Equal(ParcelSize.Large, parcel.Size);
        }

        [Fact]
        public void ExtraLargeDimesionsLowerLimitGiveExtraLargeSize()
        {
            var parcel = new Parcel(100, 100, 100, 1);
            Assert.Equal(ParcelSize.ExtraLarge, parcel.Size);
        }

        [Fact]
        public void SizeBasedOnGreatestDimension()
        {
            var smallParcel = new Parcel(3, 4, 5, 1);
            var mediumParcel = new Parcel(3, 4, 11, 1);
            var largeParcel = new Parcel(3, 75, 5, 1);
            var extraLargeParcel = new Parcel(120, 4, 5, 1);

            Assert.Equal(ParcelSize.Small, smallParcel.Size);
            Assert.Equal(ParcelSize.Medium, mediumParcel.Size);
            Assert.Equal(ParcelSize.Large, largeParcel.Size);
            Assert.Equal(ParcelSize.ExtraLarge, extraLargeParcel.Size);
        }

        [Fact]
        public void ExceptionOnNonPositiveDimensions()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Parcel(1, 2, 0, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Parcel(1, -2, 3, 1));
        }
    }
}