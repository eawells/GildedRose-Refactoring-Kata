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
                if (!specialItems.Contains(Items[i].Name) && Items[i].Quality > 0)
                {
                    if (Items[i].SellIn <= 0)
                    {
                        Items[i].Quality--;
                    }
                    Items[i].Quality--;
                }

                if (Items[i].Name == "Aged Brie" && Items[i].Quality < 50)
                {
                    Items[i].Quality++;
                }

                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert" && Items[i].Quality < 50)
                {
                    Items[i].Quality++;
                    if (Items[i].SellIn <= 10 && Items[i].Quality < 50)
                    {
                        Items[i].Quality++;
                    }
                    if (Items[i].SellIn <= 5 && Items[i].Quality < 50)
                    {
                        Items[i].Quality++;
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn--;
                }
            }
        }
    }
}
