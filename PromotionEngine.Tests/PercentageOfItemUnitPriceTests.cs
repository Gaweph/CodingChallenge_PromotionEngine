using FluentAssertions;
using PromotionEngine.Promotions;
using Xunit;

namespace PromotionEngine.Tests
{
    public class PercentageOfItemUnitPriceTests
    {
        [Fact]
        public void GetMatches__Should_Return_Expected()
        {
            // ARRANGE
            var percentage = 0.25m;
            var promotionPrice = 50;
            var promotion = new PercentageOfItemUnitPrice('A', percentage);
            var items = new[] { A, A, B, C, D }; // 2 group of [A]

            // ACT
            var matches = promotion.GetMatches(items);

            // ASSERT
            matches.Should().BeEquivalentTo(new[]
            {
                new PromotionMatch
                {
                    Items = new[] { A },
                    GroupPrice = promotionPrice * percentage
                },
                new PromotionMatch
                {
                    Items = new[] { A },
                    GroupPrice = promotionPrice * percentage
                }
            });
        }
        private CartItem A => new CartItem { Id = 'A', Price = 50 };
        private CartItem B => new CartItem { Id = 'B', Price = 30 };
        private CartItem C => new CartItem { Id = 'C', Price = 20 };
        private CartItem D => new CartItem { Id = 'D', Price = 15 };
    }
}
