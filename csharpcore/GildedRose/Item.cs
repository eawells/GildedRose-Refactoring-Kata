namespace csharpcore
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public IItemUpdateStrategy Strategy { get; set; }

        public Item(IItemUpdateStrategy strategy)
        {
            Strategy = strategy;
        }

        public void UpdateQuality()
        {
            Quality = Strategy.GetItemQuality(SellIn, Quality);
        }

        public void UpdateSellIn()
        {
            SellIn = Strategy.GetItemSellIn(SellIn, Quality);
        }
    }
}
