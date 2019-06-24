using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    DecreaseQuality(item);
                }
                else
                {
                    IncreaseQuality(item);
                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            IncreaseQuality(item);
                        }

                        if (item.SellIn < 6)
                        {
                            IncreaseQuality(item);

                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            DecreaseQuality(item);
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        IncreaseQuality(item);
                    }
                }
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
