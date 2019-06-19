using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }

        public void UpdateQuality()
        {
            var specialItems = new HashSet<string>
            {
                "Aged Brie",
                "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert",
                "Conjured Mana Cake"
            };

            foreach (var item in _items)
            {
                if (!specialItems.Contains(item.Name))
                {
                    UpdateNonSpecialItem(item);
                }

                if (item.Name == "Aged Brie")
                {
                    UpdateAgedBrie(item);
                }

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePass(item);
                }
                
                if (item.Name == "Conjured Mana Cake")
                {
                    UpdateNonSpecialItem(item);
                    UpdateNonSpecialItem(item);
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn--;
                }
            }
        }

        private void UpdateNonSpecialItem(Item nonSpecial)
        {
            if (nonSpecial.Quality > 0)
            {
                nonSpecial.Quality--;

                if (nonSpecial.SellIn <= 0 && nonSpecial.Quality > 0)
                {
                    nonSpecial.Quality--;
                }
            }
        }

        private void UpdateAgedBrie(Item agedBrie)
        {
            if (agedBrie.Quality < 50)
            {
                agedBrie.Quality++;
            }
        }

        private void UpdateBackstagePass(Item backstagePass)
        {
            if(backstagePass.Quality < 50)
            {
                backstagePass.Quality++;

                if (backstagePass.SellIn <= 10 && backstagePass.Quality < 50)
                {
                    backstagePass.Quality++;
                }

                if (backstagePass.SellIn <= 5 && backstagePass.Quality < 50)
                {
                    backstagePass.Quality++;
                }
                
                if (backstagePass.SellIn == 0)
                {
                    backstagePass.Quality = 0;
                }
            }
        }
    }
}
