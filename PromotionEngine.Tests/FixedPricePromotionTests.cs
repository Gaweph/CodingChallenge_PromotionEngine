using FluentAssertions;
using PromotionEngine.Promotions;
using Xunit;

namespace PromotionEngine.Tests
{
    public class FixedPricePromotionTests
    {
        [Fact]
        public void GetMatches__Should_Return_Expected_When_Single_Match()
        {
            // ARRANGE
            var promotionPrice = 100;
            var promotion = new FixedPricePromotion(new [] { 'A', 'B' }, promotionPrice);
            var items = new[] { A, A, B, C }; // 1 group of [A,B]

            // ACT
            var matches = promotion.GetMatches(items);

            // ASSERT
            matches.Should().BeEquivalentTo(new[]
            {
                new PromotionMatch
                    {
                        Items = new[] { A, B },
                        GroupPrice = promotionPrice
                    }
            });
        }

        [Fact]
        public void GetMatches__Should_Return_Expected_When_Multiple_Matches()
        {
            // ARRANGE
            var promotionPrice = 100;
            var promotion = new FixedPricePromotion(new[] { 'A', 'B' }, promotionPrice);
            var items = new[] { A, A, B, C, B, B, C }; // 2 groups of [A,B]

            // ACT
            var matches = promotion.GetMatches(items);

            // ASSERT
            matches.Should().BeEquivalentTo(new[]
            {
                new PromotionMatch
                {
                    Items = new[] { A, B },
                    GroupPrice = promotionPrice
                },
                new PromotionMatch
                {
                    Items = new[] { A, B },
                    GroupPrice = promotionPrice
                },
            });
        }

        private CartItem A => new CartItem { Id = 'A', Price = 50 };
        private CartItem B => new CartItem { Id = 'B', Price = 30 };
        private CartItem C => new CartItem { Id = 'C', Price = 20 };
        private CartItem D => new CartItem { Id = 'D', Price = 15 };
    }
}
