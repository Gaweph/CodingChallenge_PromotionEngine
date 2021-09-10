using FluentAssertions;
using PromotionEngine.Promotions;
using Xunit;

namespace PromotionEngine.Tests
{
    public class NItemsForFixedPriceTests
    {
        [Fact]
        public void GetMatches__Should_Return_Expected()
        {
            // ARRANGE
            var promotionPrice = 50;
            var promotion = new NItemsForFixedPrice('A', 3, promotionPrice);
            var items = new[] { A, A, B, C, A, A }; // 1 group of [A,A,A]

            // ACT
            var matches = promotion.GetMatches(items);

            // ASSERT
            matches.Should().BeEquivalentTo(new[]
            {
                new PromotionMatch
                    {
                        Items = new[] { A, A, A },
                        GroupPrice = promotionPrice
                    }
            });
        }
        private CartItem A => new CartItem { Id = 'A', Price = 50 };
        private CartItem B => new CartItem { Id = 'B', Price = 30 };
        private CartItem C => new CartItem { Id = 'C', Price = 20 };
        private CartItem D => new CartItem { Id = 'D', Price = 15 };
    }
}
