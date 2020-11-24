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

    public class BuyOneProductGetAnotherHalfPriceStrategyTests
    {
        private const int MatchingProductId = 65;
        private const int HalfPriceProductId = 71;

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(1, 1, true)]
        [InlineData(3, 1, true)]
        [InlineData(10, 9, true)]
        public void IsApplicable_ReturnsCorrectly(int numberOfMatchingProducts, int potentialHalfPriceProducts, bool expectedResult)
        {
            // Arrange
            var items = GenerateBasketItems(numberOfMatchingProducts, potentialHalfPriceProducts);
            var dto = new OfferStrategyDto(items);

            var strategy = new BuyOneProductGetAnotherHalfPriceStrategy(MatchingProductId, HalfPriceProductId);

            // Act
            var result = strategy.IsApplicable(dto);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void CalculateSavings_When_NotApplicable_ThrowsInvalidOperationException(int numberOfMatchingProducts, int potentialHalfPriceProducts)
        {
            // Arrange
            var items = GenerateBasketItems(numberOfMatchingProducts, potentialHalfPriceProducts);
            var dto = new OfferStrategyDto(items);

            var strategy = new BuyOneProductGetAnotherHalfPriceStrategy(MatchingProductId, HalfPriceProductId);

            // Act
            var ex = Record.Exception(() => strategy.Execute(dto));

            // Assert
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
        }

        [Theory]
        [ClassData(typeof(SavingsDataScenarioGenerator))]
        public void CalculateSavings_ReturnsCorrectly((int NumberOfMatchingProducts, int PotentialHalfPriceProducts, decimal UnitPrice, decimal ExpectedSaving) scenario)
        {
            // Arrange
            var items = GenerateBasketItems(scenario.NumberOfMatchingProducts, scenario.PotentialHalfPriceProducts, scenario.UnitPrice);
            var dto = new OfferStrategyDto(items);

            var strategy = new BuyOneProductGetAnotherHalfPriceStrategy(MatchingProductId, HalfPriceProductId);

            // Act
            var result = strategy.Execute(dto);

            // Assert
            Assert.Equal(scenario.ExpectedSaving, result);
        }

        private IEnumerable<BasketItemDto> GenerateBasketItems(
            int numberOfMatchingProducts, 
            int possibleHalfPriceProducts, 
            decimal unitPrice = .55M)
        {
            var items = new List<BasketItemDto>()
            {
                new BasketItemDto(1, .9m, 3),
                new BasketItemDto(2, .4m, 2),
            };

            if (numberOfMatchingProducts > 0)
            {
                var matchingProducts = new BasketItemDto(MatchingProductId, .75M, numberOfMatchingProducts);
                items.Add(matchingProducts);
            }
            
            if (possibleHalfPriceProducts > 0)
            {
                var potentialHalfPriceProducts = new BasketItemDto(HalfPriceProductId, unitPrice, possibleHalfPriceProducts);
                items.Add(potentialHalfPriceProducts);
            }

            return items;
        }

        private class SavingsDataScenarioGenerator : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var scenarios = new List<(int matchingItems, int potentialHalfPriceProducts, decimal unitPrice, decimal expectedSaving)>()
                {  
                    (
                        matchingItems : 1, 
                        potentialHalfPriceProducts: 2, 
                        unitPrice: 1M, 
                        expectedSaving: .5M
                    ),
                    (   
                        matchingItems : 2, 
                        potentialHalfPriceProducts: 2, 
                        unitPrice: 1M, 
                        expectedSaving: 1M 
                    ),
                    (
                        matchingItems : 2, 
                        potentialHalfPriceProducts: 3, 
                        unitPrice: 1M, 
                        expectedSaving: 1M
                    ),
                    (
                        matchingItems : 3, 
                        potentialHalfPriceProducts: 2, 
                        unitPrice: 1M, 
                        expectedSaving: 1M
                    ),
                    (
                        matchingItems : 10, 
                        potentialHalfPriceProducts: 10, 
                        unitPrice: 1M, 
                        expectedSaving: 5M
                    ),
                };

                return scenarios.Select(x => new object[] { x }).GetEnumerator(); 
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}
