using Xunit;
using System.Collections.Generic;
using GildedRose;
using Assert = Xunit.Assert;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
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
    }
}