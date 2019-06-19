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

        public void UpdateItem()
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

                DecreaseSellIn(item);
            }
        }

        private void UpdateNonSpecialItem(Item nonSpecial)
        {
            DecreaseQuality(nonSpecial);

            if (nonSpecial.SellIn <= 0)
            {
                DecreaseQuality(nonSpecial);
            }
        }

        private void UpdateAgedBrie(Item agedBrie)
        {
            IncreaseQuality(agedBrie);
        }

        private void UpdateBackstagePass(Item backstagePass)
        {
            IncreaseQuality(backstagePass);

            if (backstagePass.SellIn <= 10)
            {
                IncreaseQuality(backstagePass);
            }

            if (backstagePass.SellIn <= 5)
            {
                IncreaseQuality(backstagePass);
            }
            
            if (backstagePass.SellIn == 0)
            {
                backstagePass.Quality = 0;
            }
        }
        
        private void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
        
        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private void DecreaseSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn--;
            } 
        }
    }
}
