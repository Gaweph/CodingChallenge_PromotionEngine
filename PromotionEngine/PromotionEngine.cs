using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public interface IEngine
    {
        public decimal CalculateTotal(IEnumerable<CartItem> items);
    }

    public class PromotionEngine : IEngine
    {
        public decimal CalculateTotal(IEnumerable<CartItem> items)
        {
            throw new NotImplementedException();
        }
    }
}
