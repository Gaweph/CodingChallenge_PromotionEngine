using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Promotions
{
    public interface IPromotion
    {
        public IEnumerable<PromotionMatch> GetMatches(IEnumerable<CartItem> items);
    }

}
