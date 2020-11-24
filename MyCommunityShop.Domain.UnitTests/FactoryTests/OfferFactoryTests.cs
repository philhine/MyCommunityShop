namespace MyCommunityShop.Domain.UnitTests.FactoryTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MyCommunityShop.Domain.Enum;
    using MyCommunityShop.Domain.Factory;
    using MyCommunityShop.Domain.Models;
    using MyCommunityShop.Domain.Strategy;
    using Xunit;

    public class OfferFactoryTests
    {
        [Theory]
        [InlineData(OfferEnum.BuyOneGetOneFree, typeof(BuyOneGetOneFreeStrategy))]
        [InlineData(OfferEnum.BuyOneGetOneHalfPrice, typeof(BuyOneProductGetAnotherHalfPriceStrategy))]
        [InlineData(OfferEnum.ThirdOff, typeof(ThirdOffStrategy))]
        public void Get_ReturnsCorrectOfferStrategy(OfferEnum offerType, Type expectedStrategyType)
        {
            // Arrange
            var offers = new List<Offer>()
            {
                new Offer() 
                {
                    OfferType = offerType 
                }
            };

            var factory = new OfferFactory();

            // Act
            var result = factory.Get(offers);

            // Assert
            Assert.IsType(expectedStrategyType, result.First());
        }
    }
}
