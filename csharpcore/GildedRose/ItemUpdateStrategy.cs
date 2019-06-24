using csharpcore;

namespace csharpcore
{
    public interface IItemUpdateStrategy
    {
        int GetItemQuality(int sellIn, int quality);
        int GetItemSellIn(int sellIn, int quality);
    }
}

class NormalItemUpdateStrategy : IItemUpdateStrategy
{
    public int GetItemQuality(int sellIn, int quality)
    {
        if (sellIn < 0)
        {
            quality--;
        }

        return quality - 1;
    }
    
    public int GetItemSellIn(int sellIn, int quality)
    {
        return sellIn - 1;
    }
}