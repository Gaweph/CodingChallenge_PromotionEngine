using FluentAssertions;
using PromotionEngine.Promotions;
using System;
using Xunit;

namespace PromotionEngine.Tests
{
    public class PromotionEngineTests
    {
        private readonly PromotionEngine _engine;

        public PromotionEngineTests()
        {
            _engine = new PromotionEngine();

            _engine.AddPromotion(new NItemsForFixedPrice('A', 3, 130));
            _engine.AddPromotion(new NItemsForFixedPrice('B', 2, 45));
            _engine.AddPromotion(new FixedPricePromotion(new[] { 'C', 'D' }, 30));
        }

        [Fact]
        public void CalculateTotal__Should_Return_Expected_ScenarioA()
        {
            // ARRANGE
            var items = new[] { A, B, C};

            // ACT
            var total = _engine.CalculateTotal(items);

            // ASSERT
            total.Should().Be(100);
        }

        [Fact]
        public void CalculateTotal__Should_Return_Expected_ScenarioB()
        {
            // ARRANGE
            var items = new[]
            {
                A, A, A, A, A, B, B, B, B, B, C
            };

            // ACT
            var total = _engine.CalculateTotal(items);

            // ASSERT
            total.Should().Be(370);
        }

        [Fact]
        public void CalculateTotal__Should_Return_Expected_ScenarioC()
        {
            // ARRANGE
            var items = new[]
            {
                A, A, A, B, B, B, B, B, C, D
            };
            // ACT
            var total = _engine.CalculateTotal(items);

            // ASSERT
            total.Should().Be(280);
        }

        private CartItem A => new CartItem { Id = 'A', Price = 50 };
        private CartItem B => new CartItem { Id = 'B', Price = 30 };
        private CartItem C => new CartItem { Id = 'C', Price = 20 };
        private CartItem D => new CartItem { Id = 'D', Price = 15 };
    }
}
