using Xunit;
using System.Collections.Generic;
using GildedRose;
using Assert = Xunit.Assert;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private const string LegendaryItemName = "Sulfuras, Hand of Ragnaros";
        private const int LegendaryQuality = 80;

        [Fact]
        public void UpdateQuality_ShouldNotReduceQualityOfExpiredItem()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose.GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldNotIncreaseQualityOfAgedBrieAboveFifty()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
            var app = new GildedRose.GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldReduceQualityByTwo_WhenSellInIsZero()
        {
            const int quality = 10;
            var items = new List<Item> { new Item { Name = "some item", SellIn = 0, Quality = quality } };
            var app = new GildedRose.GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(quality - 2, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldReduceQualityByOne_WhenSellInAboveZeroForNormalItem()
        {
            const int quality = 10;
            var items = new List<Item> { new Item { Name = "some item", SellIn = 1, Quality = quality } };
            var app = new GildedRose.GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(quality - 1, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldIncreaseQualityByOne_WhenItemIsAgedBrie()
        {
            const int quality = 10;
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = quality } };
            var app = new GildedRose.GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(quality + 1, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldNotChangeInQuality_WhenItemIsLegendary()
        {
            var items = new List<Item>
                { new Item { Name = LegendaryItemName, SellIn = 10, Quality = LegendaryQuality } };
            var app = new GildedRose.GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(LegendaryQuality, items[0].Quality);
        }


        [Fact]
        public void UpdateQuality_ShouldNotChangeInSellIn_WhenItemIsLegendary()
        {
            const int sellIn = 10;

            var items = new List<Item>
                { new Item { Name = LegendaryItemName, SellIn = sellIn, Quality = LegendaryQuality } };
            var app = new GildedRose.GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(LegendaryQuality, items[0].Quality);
        }
    }
}