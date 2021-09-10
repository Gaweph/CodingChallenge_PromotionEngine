using PromotionEngine.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public interface IPromotionEngine
    {
        public void AddPromotion(IPromotion promotion);
        public decimal CalculateTotal(IEnumerable<CartItem> items);
    }

    public class PromotionEngine : IPromotionEngine
    {
        private readonly List<IPromotion> _promotions;

        public PromotionEngine()
        {
            _promotions = new List<IPromotion>();
        }

        public void AddPromotion(IPromotion promotion)
        {
            _promotions.Add(promotion);
        }

        public decimal CalculateTotal(IEnumerable<CartItem> items)
        {
            var list = items.ToList();
            var total = 0M;
            foreach(var p in _promotions)
            {
                var matches = p.GetMatches(list);
                var matchesItems = matches.SelectMany(x => x.Items);
                foreach (var item in matchesItems)
                {
                    list.Remove(item); // item can only be used in 1 promotion
                }

                total += matches.Sum(x => x.GroupPrice);
            }

            foreach(var item in list)
            {
                // add items not part of a promotion
                total += item.Price;
            }

            return total;
        }
    }
}
