using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        private readonly HashSet<string> _specialItems = new HashSet<string>
        {
            "Aged Brie",
            "Backstage passes to a TAFKAL80ETC concert",
            "Conjured Mana Cake"
        };

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateItems()
        {
            foreach (var item in _items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                if (!_specialItems.Contains(item.Name))
                {
                    UpdateNormalItemQuality(item);
                }

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePassesQuality(item);
                }

                if (item.Name == "Aged Brie")
                {
                    UpdateAgedBrieQuality(item);
                }

                if (item.Name == "Conjured Mana Cake")
                {
                    UpdateConjuredItemQuality(item);
                }

                item.SellIn = item.SellIn - 1;
            }
        }

        private void UpdateNormalItemQuality(Item normalItem)
        {
            DecreaseQuality(normalItem);
            if (normalItem.SellIn <= 0)
            {
                DecreaseQuality(normalItem);
            }
        }

        private void UpdateAgedBrieQuality(Item agedBrie)
        {
            IncreaseQuality(agedBrie);
            if (agedBrie.SellIn <= 0)
            {
                IncreaseQuality(agedBrie);
            }
        }

        private void UpdateBackstagePassesQuality(Item backstagePasses)
        {
            if (backstagePasses.SellIn <= 0)
            {
                backstagePasses.Quality = 0;
                return;
            }

            IncreaseQuality(backstagePasses);

            if (backstagePasses.SellIn < 11)
            {
                IncreaseQuality(backstagePasses);
            }

            if (backstagePasses.SellIn < 6)
            {
                IncreaseQuality(backstagePasses);
            }
        }

        private void UpdateConjuredItemQuality(Item conjuredItem)
        {
            UpdateNormalItemQuality(conjuredItem);
            UpdateNormalItemQuality(conjuredItem);
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Quality <= 0) return;
            item.Quality = item.Quality - 1;
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}
