using System;
using System.Collections.Generic;

namespace PromotionEngine.Promotions
{
    // buy SKU 1 & SKU 2 for a fixed price ( C + D = 30 )
    public class FixedPricePromotion : IPromotion
    {
        private readonly decimal Price;
        private readonly char[] Ids;
        public FixedPricePromotion(char[] ids, decimal price)
        {
            Ids = ids;
            Price = price;
        }

        public IEnumerable<PromotionMatch> GetMatches(IEnumerable<CartItem> allItems)
        {
            throw new NotImplementedException();
        }
    }

}
