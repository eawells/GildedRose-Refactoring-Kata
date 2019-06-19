using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            HashSet<string> specialItems = new HashSet<string>
            {
                "Aged Brie",
                "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert",
                "Conjured Mana Cake"
            };

            for (var i = 0; i < Items.Count; i++)
            {
                if (!specialItems.Contains(Items[i].Name))
                {
                    UpdateNonSpecialItem(Items[i]);
                }

                if (Items[i].Name == "Aged Brie")
                {
                    UpdateAgedBrie(Items[i]);
                }

                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePass(Items[i]);
                }
                
                if (Items[i].Name == "Conjured Mana Cake")
                {
                    UpdateNonSpecialItem(Items[i]);
                    UpdateNonSpecialItem(Items[i]);
                }
            }
        }

        private void UpdateNonSpecialItem(Item nonSpecial)
        {
            if (nonSpecial.Quality > 0)
            {
                if (nonSpecial.SellIn <= 0)
                {
                    nonSpecial.Quality--;
                }

                nonSpecial.Quality--;
            }

            nonSpecial.SellIn--;
        }

        private void UpdateAgedBrie(Item agedBrie)
        {
            if (agedBrie.Quality < 50)
            {
                agedBrie.Quality++;
            }

            agedBrie.SellIn--;
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
            
            backstagePass.SellIn--;
        }
    }
}
