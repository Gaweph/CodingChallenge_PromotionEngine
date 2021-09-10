using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Promotions
{
    // x% of a SKU unit price
    public class PercentageOfItemUnitPrice : IPromotion
    {
        private readonly decimal _percentage;
        private readonly char _id;
        public PercentageOfItemUnitPrice(char id, decimal percentage)
        {
            _id = id;
            _percentage = percentage;
        }

        public IEnumerable<PromotionMatch> GetMatches(IEnumerable<CartItem> items)
        {
            return items.Where(x => x.Id == _id).Select(x => new PromotionMatch
            {
                GroupPrice = x.Price * _percentage,
                Items = new[] { x }
            });
        }
    }

}
