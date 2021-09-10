using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Promotions
{

    // buy SKU 1 & SKU 2 for a fixed price ( C + D = 30 )
    public class FixedPricePromotion : IPromotion
    {
        private readonly decimal _price;
        private readonly char[] _ids;
        public FixedPricePromotion(char[] ids, decimal price)
        {
            _ids = ids;
            _price = price;
        }

        public IEnumerable<PromotionMatch> GetMatches(IEnumerable<CartItem> items)
        {
            // Only interested in subset of items
            var itemsOfInterest = items.Where(x => _ids.Contains(x.Id)).ToList();

            var matches = new List<PromotionMatch>();
            while (TryGetNextMatch(itemsOfInterest, out var match))
            {
                matches.Add(match);
            }

            return matches;
        }

        private bool TryGetNextMatch(List<CartItem> items, out PromotionMatch match)
        {
            var matchingItems = new List<CartItem>();
            foreach (var id in _ids)
            {
                var item = items.FirstOrDefault(x => x.Id == id);
                if (item != null)
                {
                    matchingItems.Add(item);
                    items.Remove(item);
                }
            }

            if (matchingItems.Count == _ids.Length)
            {
                match = new PromotionMatch
                {
                    GroupPrice = _price,
                    Items = matchingItems
                };
                return true;
            }
            else
            {
                match = null;
                return false;
            }

        }
    }

}
