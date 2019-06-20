using csharpcore;

namespace csharpcore
{
    public interface IQualityUpdateStrategy
    {
        int GetItemQuality(int sellIn, int quality);
        int GetItemSellIn(int sellIn, int quality);
    }
}

class NormalQualityUpdateStrategy : IQualityUpdateStrategy
{
    public int GetItemQuality(int sellIn, int quality)
    {
        return quality - 1;
    }
    
    public int GetItemSellIn(int sellIn, int quality)
    {
        return sellIn - 1;
    }
}