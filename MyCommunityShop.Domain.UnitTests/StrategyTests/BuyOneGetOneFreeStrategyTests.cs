namespace MyCommunityShop.Domain.UnitTests.StrategyTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using MyCommunityShop.Domain.Services.Basket.Dtos;
    using MyCommunityShop.Domain.Strategy;
    using MyCommunityShop.Domain.Strategy.Dtos;
    using Xunit;

    public class BuyOneGetOneFreeStrategyTests
    {
        private const int MatchingProductId = 56;

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(10, true)]
        public void IsApplicable_ReturnsCorrectly(int numberOfMatchingProducts, bool expectedResult)
        {
            // Arrange
            var items = GenerateBasketItems(numberOfMatchingProducts);
            var dto = new OfferStrategyDto(items);

            var strategy = new BuyOneGetOneFreeStrategy(MatchingProductId);

            // Act
            var result = strategy.IsApplicable(dto);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CalculateSavings_When_NotApplicable_ThrowsInvalidOperationException(int numberOfMatchingProducts)
        {
            // Arrange
            var items = GenerateBasketItems(numberOfMatchingProducts);
            var dto = new OfferStrategyDto(items);

            var strategy = new BuyOneGetOneFreeStrategy(MatchingProductId);

            // Act
            var ex = Record.Exception(() => strategy.Execute(dto));

            // Assert
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
        }

        [Theory]
        [ClassData(typeof(SavingsDataScenarioGenerator))]
        public void CalculateSavings_ReturnsCorrectly((int NumberOfMatchingProducts, decimal UnitPrice, decimal ExpectedSaving) scenario)
        {
            // Arrange
            var items = GenerateBasketItems(scenario.NumberOfMatchingProducts, scenario.UnitPrice);
            var dto = new OfferStrategyDto(items);

            var strategy = new BuyOneGetOneFreeStrategy(MatchingProductId);

            // Act
            var result = strategy.Execute(dto);

            // Assert
            Assert.Equal(scenario.ExpectedSaving, result);
        }

        private IEnumerable<BasketItemDto> GenerateBasketItems(int numberOfMatchingProducts, decimal unitPrice = .65M)
        {
            var items = new List<BasketItemDto>()
            {
                new BasketItemDto(1, .9m, 1),
                new BasketItemDto(2, .4m, 1),
            };

            if (numberOfMatchingProducts > 0)
            {
                var matchingItem = new BasketItemDto(MatchingProductId, unitPrice, numberOfMatchingProducts);
                items.Add(matchingItem);
            }

            return items;
        }

        private class SavingsDataScenarioGenerator : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var scenarios = new List<(int matchingItems, decimal unitPrice, decimal expectedSaving)>()
                {
                    (
                        matchingItems : 2,
                        unitPrice: 1M,
                        expectedSaving: 1M
                    ),
                    (
                        matchingItems : 5,
                        unitPrice: 1M,
                        expectedSaving: 2M
                    ),
                    (
                        matchingItems : 10,
                        unitPrice: 1M,
                        expectedSaving: 5M
                    ),
                    (
                        matchingItems : 100,
                        unitPrice: 1M,
                        expectedSaving: 50M
                    ),
                };

                return scenarios.Select(x => new object[] { x }).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}
