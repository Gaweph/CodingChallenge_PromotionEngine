using System.Linq;

namespace PromotionEngine.Promotions
{
    // buy 'n' items of a SKU for a fixed price (3 A's for 130)
    public class NItemsForFixedPrice : FixedPricePromotion
    {
        public NItemsForFixedPrice(char id, int numberOfItems, decimal price) :
            base(new int[numberOfItems].Select(x => id).ToArray(), price)
        { }
    }

}
