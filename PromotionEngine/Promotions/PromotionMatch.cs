using System.Collections.Generic;

namespace PromotionEngine.Promotions
{
    public class PromotionMatch
    {
        public IEnumerable<CartItem> Items { get; set; }
        public decimal GroupPrice { get; set; }
    }

}
