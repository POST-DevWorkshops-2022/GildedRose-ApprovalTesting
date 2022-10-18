using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using ApprovalTests.Reporters;
using ApprovalTests;
using Newtonsoft.Json;
using ApprovalTests.Combinations;

namespace CSharpCore.Test
{
    [UseReporter(typeof(VisualStudioReporter))]
    public class GildedRoseTest
    {
        [Fact]
        public void ShouldHaveItemWithExpectedName()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Items[0].Name.Should().Be("foo");
        }

        [Fact]
        [UseReporter(typeof(VisualStudioReporter))]
        public void VerifyStandardItemByToString()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Approvals.Verify(Items[0].ToString());
        }

        [Fact]
        [UseReporter(typeof(VisualStudioReporter))]
        public void VerifyStandardItemWithJson()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Approvals.Verify(JsonConvert.SerializeObject(Items[0]));
        }

        [Fact]
        [UseReporter(typeof(VisualStudioReporter))]
        public void VerifyStandardJsonItem()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Approvals.VerifyJson(JsonConvert.SerializeObject(Items[0]));
        }

        [Fact]
        [UseReporter(typeof(VisualStudioReporter))]
        public void VerifyAllItemCombinations()
        {
            string[] names = { "foo", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros", };
            int[] quality = { 0, 1, 49, 50 };
            int[] sellIn = { -1, 0, 2, 6, 11 };

            CombinationApprovals.VerifyAllCombinations(doUpdateQuality, names, sellIn, quality);
        }

        private string doUpdateQuality(string name, int sellIn, int quality)
        {
            Item[] items = new Item[] { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            return JsonConvert.SerializeObject(items[0]);
        }
    }
}
