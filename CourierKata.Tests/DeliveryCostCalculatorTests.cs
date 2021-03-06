using CourierKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.Equal(ParcelType.Small, result.DeliveryItems[0].Type);
            Assert.Equal(300, result.TotalCostCents);
        }

        [Fact]
        public void CalculateCost_Single_MediumParcel()
        {
            var parcel = new Parcel(5, 10, 20, 1);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            Assert.Equal(ParcelType.Medium, result.DeliveryItems[0].Type);
            Assert.Equal(800, result.TotalCostCents);
        }

        [Fact]
        public void CalculateCost_Single_LargeParcel()
        {
            var parcel = new Parcel(80, 10, 20, 1);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            Assert.Equal(ParcelType.Large, result.DeliveryItems[0].Type);
            Assert.Equal(1500, result.TotalCostCents);
        }

        [Fact]
        public void CalculateCost_Single_ExtraLargeParcel()
        {
            var parcel = new Parcel(110, 50, 20, 1);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            Assert.Equal(ParcelType.ExtraLarge, result.DeliveryItems[0].Type);
            Assert.Equal(2500, result.TotalCostCents);
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

            Assert.Equal(expected, result.TotalCostCents);
        }

        [Fact]
        public void CalculateCost_Single_SpeedyShipping()
        {
            var parcel = new Parcel(5, 15, 20, 1);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            Assert.Equal(1600, result.SpeedyShippingCostCents);
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

            Assert.Equal(expected, result.SpeedyShippingCostCents);
        }

        [Fact]
        public void CalculateCost_Single_ExcessWeightCharged()
        {
            var parcel = new Parcel(1, 1, 1, weightKilograms: 2);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            var individualParcelCost = result.DeliveryItems.First(c => c.Parcel == parcel).TotalCostCents;
            Assert.Equal(300 + 200, individualParcelCost);
        }

        [Fact]
        public void CalculateCost_Multiple_ExcessWeightCharged()
        {
            var parcels = new List<Parcel>()
            {
                new Parcel(1, 2, 3, 1),        // small, $3, 0kg excess
                new Parcel(3, 5, 10, 6),       // medium, $8, 3kg excess
                new Parcel(10, 15, 60, 1),     // large, $15, 0kg excess
                new Parcel(150, 40, 40, 15),    // extra large, $25, 5kg excess
            };

            var expectedBaseCost = (300 + 800 + 1500 + 2500);
            var expectedExcessCost = (3 + 5) * 200;
            var expectedTotal = expectedBaseCost + expectedExcessCost;

            var result = DeliveryCostCalculator.CalculateCost(parcels);

            Assert.Equal(expectedTotal, result.TotalCostCents);
        }

        [Fact]
        public void CalculateCost_Single_Heavy()
        {
            var parcel = new Parcel(1, 1, 1, weightKilograms: 50);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            var individualParcelCost = result.DeliveryItems.First(c => c.Parcel == parcel).TotalCostCents;
            Assert.Equal(ParcelType.Heavy, result.DeliveryItems[0].Type);
            Assert.Equal(5000, individualParcelCost);
        }

        [Fact]
        public void CalculateCost_Single_ExtraLargeCheaperThanHeavy()
        {
            var parcel = new Parcel(100, 100, 100, weightKilograms: 22);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            var individualParcelCost = result.DeliveryItems.First(c => c.Parcel == parcel).TotalCostCents;
            Assert.Equal(ParcelType.ExtraLarge, result.DeliveryItems[0].Type);
            Assert.Equal(4900, individualParcelCost);
        }

        [Fact]
        public void CalculateCost_Single_HeavyCheaperThanExtraLarge()
        {
            var parcel = new Parcel(100, 100, 100, weightKilograms: 23);
            var result = DeliveryCostCalculator.CalculateCost(parcel);
            var individualParcelCost = result.DeliveryItems.First(c => c.Parcel == parcel).TotalCostCents;
            Assert.Equal(ParcelType.Heavy, result.DeliveryItems[0].Type);
            Assert.Equal(5000, individualParcelCost);
        }
    }
}
