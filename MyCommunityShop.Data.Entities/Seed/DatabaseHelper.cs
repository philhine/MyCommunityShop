namespace MyCommunityShop.Data.Entities.Seed
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using MyCommunityShop.Domain.Enum;

    public class DatabaseHelper
    {
        private const string Bread = "Bread";
        private const string Milk = "Milk";
        private const string Cheese = "Cheese";
        private const string Soup = "Soup";
        private const string Butter = "Butter";

        public static void SeedDatabase(DataContext context)
        {
            SeedProducts(context);
            SeedOffers(context);
        }

        private static void SeedProducts(DataContext context)
        {
            var products = new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = 1,
                    Name = Bread,
                    UnitPrice = 1.1M,
                },
                new ProductEntity()
                {
                    Id = 2,
                    Name = Milk,
                    UnitPrice = .5M,
                },
                new ProductEntity()
                {
                    Id = 3,
                    Name = Cheese,
                    UnitPrice = .9M,
                },
                new ProductEntity()
                {
                    Id = 4,
                    Name = Soup,
                    UnitPrice = .6M,
                },
                new ProductEntity()
                {
                    Id = 5,
                    Name = Butter,
                    UnitPrice = 1.2M,
                },
            };

            context.AddRange(products);
            context.SaveChanges();
        }

        private static void SeedOffers(DataContext context)
        {
            var offers = new List<OfferEntity>()
            {
                new OfferEntity()
                {
                    Id = 1,
                    Description = $"When you buy a {Cheese}, you get a second for {Cheese} free",
                    OfferType = (int)OfferEnum.BuyOneGetOneFree,
                    MatchingProductId = GetProductId(context, Cheese),
                    SavingProductId = GetProductId(context, Cheese),
                },
                new OfferEntity()
                {
                    Id = 2,
                    Description = $"When you buy a {Soup}, you get a half price {Bread}!",
                    OfferType = (int)OfferEnum.BuyOneGetOneHalfPrice,
                    MatchingProductId = GetProductId(context, Soup),
                    SavingProductId = GetProductId(context, Bread),
                },
                new OfferEntity()
                {
                    Id = 3,
                    Description = $"Get a third off {Butter}",
                    OfferType = (int)OfferEnum.ThirdOff,
                    MatchingProductId = GetProductId(context, Butter),
                    SavingProductId = GetProductId(context, Butter),
                },
            };

            context.AddRange(offers);
            context.SaveChanges();
        }

        private static int GetProductId(DataContext context, string name)
        {
            return context.Products.First(x => x.Name == name).Id;
        }
    }
}
