using CourierKata.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CourierKata.Tests
{
    public class DeliveryCostCalculatorTests
    {
        [Fact]
        public void CalculateCost_Single_ExceptionOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => DeliveryCostCalculator.CalculateCost(parcel: null));
        }

        [Fact]
        public void CalculateCost_Multiple_ExceptionOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => DeliveryCostCalculator.CalculateCost(parcels: null));
        }

        [Fact]
        public void CalculateCost_Single_SmallParcel()
        {
            var parcel = new Parcel(1, 1, 1, 1);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            Assert.Equal(300, result.TotalCostPence);
        }

        [Fact]
        public void CalculateCost_Single_MediumParcel()
        {
            var parcel = new Parcel(5, 10, 20, 1);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            Assert.Equal(800, result.TotalCostPence);
        }

        [Fact]
        public void CalculateCost_Single_LargeParcel()
        {
            var parcel = new Parcel(80, 10, 20, 1);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            Assert.Equal(1500, result.TotalCostPence);
        }

        [Fact]
        public void CalculateCost_Single_ExtraLargeParcel()
        {
            var parcel = new Parcel(110, 50, 20, 1);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            Assert.Equal(2500, result.TotalCostPence);
        }

        [Fact]
        public void CalculateCost_Multiple()
        {
            var parcels = new List<Parcel>()
            { 
                new Parcel(3, 5, 8, 1),        // small, $3
                new Parcel(3, 5, 10, 1),       // medium, $8
                new Parcel(10, 15, 30, 1),     // medium, $8
                new Parcel(10, 15, 60, 1),     // large, $15
                new Parcel(150, 40, 40, 1),    // extra large, $25
                new Parcel(1, 1, 111, 1),      // extra large, $25
            };

            var expected = 300 + 800 + 800 + 1500 + 2500 + 2500;

            var result = DeliveryCostCalculator.CalculateCost(parcels);

            Assert.Equal(expected, result.TotalCostPence);
        }

        [Fact]
        public void CalculateCost_Single_SpeedyShipping()
        {
            var parcel = new Parcel(5, 15, 20, 1);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            Assert.Equal(1600, result.SpeedyShippingCostPence);
        }

        [Fact]
        public void CalculateCost_Multiple_SpeedyShipping()
        {
            var parcels = new List<Parcel>()
            {
                new Parcel(3, 5, 8, 1),        // small, $3
                new Parcel(3, 5, 10, 1),       // medium, $8
                new Parcel(10, 15, 60, 1),     // large, $15
                new Parcel(150, 40, 40, 1),    // extra large, $25
            };

            var expected = (300 + 800 + 1500 + 2500) * 2;

            var result = DeliveryCostCalculator.CalculateCost(parcels);

            Assert.Equal(expected, result.SpeedyShippingCostPence);
        }
    }
}
