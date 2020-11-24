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

    public class ThirdOffStrategyTests
    {
        private const int MatchingProductId = 43;

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(10, true)]
        public void IsApplicable_ReturnsCorrectly(int numberOfMatchingProducts, bool expectedResult)
        {
            // Arrange
            var items = GenerateBasketItems(numberOfMatchingProducts);
            var dto = new OfferStrategyDto(items);

            var strategy = new ThirdOffStrategy(MatchingProductId);

            // Act
            var result = strategy.IsApplicable(dto);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0)]
        public void CalculateSavings_When_NotApplicable_ThrowsInvalidOperationException(int numberOfMatchingProducts)
        {
            // Arrange
            var items = GenerateBasketItems(numberOfMatchingProducts);
            var dto = new OfferStrategyDto(items);

            var strategy = new ThirdOffStrategy(MatchingProductId);

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

            var strategy = new ThirdOffStrategy(MatchingProductId);

            // Act
            var result = strategy.Execute(dto);

            // Assert
            Assert.Equal(scenario.ExpectedSaving, result);
        }

        private IEnumerable<BasketItemDto> GenerateBasketItems(int numberOfMatchingProducts, decimal unitPrice = .65M)
        {
            var items = new List<BasketItemDto>()
            {
                new BasketItemDto(1, .9m, 3),
                new BasketItemDto(2, .4m, 4),
            };
            
            if (numberOfMatchingProducts > 0)
            {
                var matchingProducts = new BasketItemDto(MatchingProductId, unitPrice, numberOfMatchingProducts);
                items.Add(matchingProducts);
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
                        matchingItems : 1,
                        unitPrice: 3M,
                        expectedSaving: 1M
                    ),
                    (
                        matchingItems : 2,
                        unitPrice: 3M,
                        expectedSaving: 2M
                    ),
                    (
                        matchingItems : 30,
                        unitPrice: 1M,
                        expectedSaving: 10M
                    ),
                };

                return scenarios.Select(x => new object[] { x }).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}
