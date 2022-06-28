using CourierKata.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CourierKata.Tests
{
    public class DeliveryCostSummaryTests
    {
        [Fact]
        public void ExceptionOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DeliveryCostSummary(parcelCosts: null));
        }

        [Fact]
        public void TotalIsZeroForEmptyList()
        {
            var parcelCosts = new List<ParcelCost>();
            var summary = new DeliveryCostSummary(parcelCosts);
            Assert.Equal(0, summary.TotalCostPence);
        }

        [Fact]
        public void SingleItemGivesCorrectTotal()
        {
            var parcel = new Parcel(1, 2, 3, 1);
            var parcelCost = new ParcelCost()
            {
                Parcel = parcel,
                BaseSizeCostPence = 99
            };
            var parcelCosts = new List<ParcelCost>() { parcelCost };
            var summary = new DeliveryCostSummary(parcelCosts);
            Assert.Equal(99, summary.TotalCostPence);
        }

        [Fact]
        public void MultipleItemsGivesCorrectTotal()
        {
            var parcelCost1 = new ParcelCost()
            {
                Parcel = new Parcel(1, 2, 3, 1),
                BaseSizeCostPence = 99
            };
            var parcelCost2 = new ParcelCost()
            {
                Parcel = new Parcel(1, 2, 3, 1),
                BaseSizeCostPence = 250
            };
            var parcelCost3 = new ParcelCost()
            {
                Parcel = new Parcel(1, 2, 3, 1),
                BaseSizeCostPence = 10000
            };
            var parcelCosts = new List<ParcelCost>() { parcelCost1, parcelCost2, parcelCost3 };
            var summary = new DeliveryCostSummary(parcelCosts);
            Assert.Equal(10349, summary.TotalCostPence);
        }

        [Fact]
        public void SingleItemSpeedyShippingIsDouble()
        {
            var parcel = new Parcel(1, 2, 3, 1);
            var parcelCost = new ParcelCost()
            {
                Parcel = parcel,
                BaseSizeCostPence = 99
            };
            var parcelCosts = new List<ParcelCost>() { parcelCost };
            var summary = new DeliveryCostSummary(parcelCosts);
            Assert.Equal(99, summary.TotalCostPence);
            Assert.Equal(198, summary.SpeedyShippingCostPence);
        }
    }
}
