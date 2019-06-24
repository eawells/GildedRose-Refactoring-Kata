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
                    DecreaseQuality(item);
                    DecreaseQuality(item);
                    if (item.SellIn <= 0)
                    {
                        DecreaseQuality(item);
                        DecreaseQuality(item);
                    }
                }

                item.SellIn = item.SellIn - 1;
            }
        }

        private void UpdateNormalItemQuality(Item item)
        {
            DecreaseQuality(item);
            if (item.SellIn <= 0)
            {
                DecreaseQuality(item);
            }
        }

        private void UpdateAgedBrieQuality(Item item)
        {
            IncreaseQuality(item);
            if (item.SellIn <= 0)
            {
                IncreaseQuality(item);
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

        private void DecreaseQuality(Item item)
        {
            if (item.Quality <= 0) return;
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.Quality = item.Quality - 1;
            }
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
