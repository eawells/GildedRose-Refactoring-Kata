﻿using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void GivenANonSpecialItem_WhenADayPasses_ThenTheSellInDecreasesByOne()
        {
            IList<Item> items = new List<Item> { new Item() { Name = "foo", SellIn = 1, Quality = 1 }};
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(0, items[0].SellIn);
        }
        
        [Fact]
        public void GivenANonSpecialItem_WhenADayPasses_ThenTheQualityDecreasesByOne()
        {
            IList<Item> items = new List<Item> { new Item() { Name = "foo", SellIn = 1, Quality = 1 }};
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(0, items[0].Quality);
        }
        
        [Fact]
        public void GivenANonSpecialItemHasANegativeSellIn_WhenADayPasses_ThenQualityDecreasesByTwo()
        {
            IList<Item> items = new List<Item> { new Item() { Name = "foo", SellIn = -1, Quality = 2 }};
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(0, items[0].Quality);
        }
        
        [Fact]
        public void GivenANonSpecialItemHasANegativeSellIn_WhenADayPassesAndQualityIsOne_ThenQualityDecreasesToZero()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "foo", SellIn = -1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(0, Items[0].Quality);
        }
        
        [Fact]
        public void GivenANonSpecialItemHasQualityZero_WhenADayPasses_ThenQualityDoesNotDecrease()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "foo", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(0, Items[0].Quality);
        }
        
        [Fact]
        public void GivenNonSpecialItem__WhenADayPasses_ThenTheSellInDecreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "foo", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(0, Items[0].SellIn);
        }
        
        [Fact]
        public void GivenAgedBrie_WhenADayPasses_ThenTheQualityIncreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Aged Brie", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(1, Items[0].Quality);
        }
        
        [Fact]
        public void GivenAgedBrieHasSellIn0_WhenADayPasses_ThenTheQualityIncreasesByTwo()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void GivenAgedBrie_WhenADayPasses_ThenTheSellInDecreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Aged Brie", SellIn = 1, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(0, Items[0].SellIn);
        }
        
        [Fact]
        public void GivenAgedBrieHasQuality50_WhenADayPasses_ThenTheQualityDoesNotIncrease()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(50, Items[0].Quality);
        }
        
        [Fact]
        public void GivenSulfras_WhenADayPasses_ThenTheQualityDoesNotChange()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(80, Items[0].Quality);
        }
        
        [Fact]
        public void GivenSulfras_WhenADayPasses_ThenTheSellInDoesNotChange()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(1, Items[0].SellIn);
        }
        
        [Fact]
        public void GivenBackstagePassesHaveSellIn11_WhenADayPasses_ThenTheQualityIncreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(2, Items[0].Quality);
        }
        
        [Fact]
        public void GivenBackstagePassesHaveSellIn10_WhenADayPasses_ThenTheQualityIncreasesByTwo()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(3, Items[0].Quality);
        }
        
        [Fact]
        public void GivenBackstagePassesHaveSellIn5_WhenADayPasses_ThenTheQualityIncreasesByThree()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(4, Items[0].Quality);
        }
        
        [Fact]
        public void GivenBackstagePassesHaveSellIn1_WhenADayPasses_ThenTheQualityIncreasesByThree()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(4, Items[0].Quality);
        }
        
        [Fact]
        public void GivenBackstagePassesHaveSellIn0_WhenADayPasses_ThenTheQualityIsZero()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(0, Items[0].Quality);
        }
        
        [Fact]
        public void GivenBackstagePasses_WhenADayPasses_ThenTheSellInDecreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(0, Items[0].SellIn);
        }
        
        [Fact]
        public void GivenBackstagePassesHaveQuality50_WhenADayPasses_ThenTheQualityRemains50()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(50, Items[0].Quality);
        }
        
        [Fact]
        public void GivenBackstagePassesHaveSellIn10_WhenADayPasses_ThenTheQualityDoesNotExceed50()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void GivenBackstagePassesHaveSellIn5_WhenADayPasses_ThenTheQualityDoesNotExceed50()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 48 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void GivenConjuredItem_WhenADayPasses_ThenTheQualityGoesDownByTwo()
        {
            IList<Item> Items = new List<Item> { new Item() { Name = "Conjured Mana Cake", SellIn = 5, Quality = 48 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.Equal(46, Items[0].Quality);
        }

        [Fact]
        public void GivenConjuredItem_WhenADayPasses_ThenTheSellInDecreasesByOne()
        {
            IList<Item> items = new List<Item> { new Item() { Name = "Conjured Mana Cake", SellIn = 1, Quality = 1 }};
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(0, items[0].SellIn);
        }

        [Fact]
        public void GivenConjuredItemHasSellInZero_WhenADayPasses_ThenTheSellInDecreasesByFour()
        {
            IList<Item> items = new List<Item> { new Item() { Name = "Conjured Mana Cake", SellIn = 0, Quality = 5 }};
            GildedRose app = new GildedRose(items);
            app.UpdateItems();
            Assert.Equal(1, items[0].Quality);
        }
    }
}