using Xunit;
using System.Collections.Generic;
using GildedRose;

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
    }
}