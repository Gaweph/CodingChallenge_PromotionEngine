using PromotionEngine.Promotions;
using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IEngine
    {
        public void AddPromotion(IPromotion promotion);
        public decimal CalculateTotal(IEnumerable<CartItem> items);
    }

    public class PromotionEngine : IEngine
    {
        private readonly List<IPromotion> Promotions;

        public PromotionEngine()
        {
            Promotions = new List<IPromotion>();
        }

        public void AddPromotion(IPromotion promotion)
        {
            Promotions.Add(promotion);
        }

        public decimal CalculateTotal(IEnumerable<CartItem> items)
        {
            throw new NotImplementedException();
        }
    }
}
