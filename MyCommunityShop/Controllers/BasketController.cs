namespace MyCommunityShop.Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MyCommunityShop.Api.Interfaces;
    using MyCommunityShop.Api.Models;
    using MyCommunityShop.Domain.Interfaces;
    using MyCommunityShop.Domain.Models;
    using MyCommunityShop.Domain.Services.Basket;
    using MyCommunityShop.Domain.Services.Basket.Dtos;

    /// <summary>
    /// The shopping basket Resource
    /// </summary>
    [Route("api/baskets")]
    public class BasketController : ControllerBase
    {
        private readonly ILinkFactory<BasketViewModel> linkFactory;
        private readonly IService<Basket> createBasketService;
        private readonly IMapper mapper;
        private readonly IService<int, Basket> getBasketServiceById;
        private readonly IService<AddProductToBasketServiceDto, Basket> addProductToBasketService;
        private readonly IService<RemoveProductFromBasketServiceDto, Basket> removeProductFromBasketService;

        public BasketController(
            ILinkFactory<BasketViewModel> linkFactory,
            IService<Basket> createBasketService, 
            IMapper mapper,
            IService<int, Basket> getBasketServiceById,
            IService<AddProductToBasketServiceDto, Basket> addProductToBasketService,
            IService<RemoveProductFromBasketServiceDto, Basket> removeProductFromBasketService)
        {
            this.linkFactory = linkFactory ?? throw new System.ArgumentNullException(nameof(linkFactory));
            this.createBasketService = createBasketService ?? throw new System.ArgumentNullException(nameof(createBasketService));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            this.getBasketServiceById = getBasketServiceById ?? throw new System.ArgumentNullException(nameof(getBasketServiceById));
            this.addProductToBasketService = addProductToBasketService ?? throw new System.ArgumentNullException(nameof(addProductToBasketService));
            this.removeProductFromBasketService = removeProductFromBasketService ?? throw new System.ArgumentNullException(nameof(removeProductFromBasketService));
        }

        /// <summary>
        /// Creates a new basket
        /// </summary>
        /// <returns>The new basket</returns>
        [HttpPost(Name = "CreateBasket")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Post()
        {
            var model = await this.createBasketService.Execute();

            var basket = this.mapper.Map<BasketViewModel>(model);
            var links = this.linkFactory.Create(basket, Url);
            basket.Links = links;

            //todo: constant of self
            var newBasketLink = links.First(x => x.Rel == "self");

            //todo: set to created
            return Ok(basket);
        }

        /// <summary>
        /// Gets the basket contents
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBasket")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await this.getBasketServiceById.Execute(id);

            if (model == null)
            {
                return NotFound();
            }

            var basket = this.mapper.Map<BasketViewModel>(model);
            var links = this.linkFactory.Create(basket, Url);
            basket.Links = links;

            return Ok(basket);
        }


        /// <summary>
        /// Adds a product to the basket
        /// </summary>
        /// <param name="id">Basket Id</param>
        /// <param name="productId">Product Id to add</param>
        /// <returns></returns>
        [HttpPost("{id}/product/{productId}", Name = "AddProductToBasket")]
        public async Task<IActionResult> Post(int id, int productId)
        {
            var dto = new AddProductToBasketServiceDto(id, productId);
            var model = await this.addProductToBasketService.Execute(dto);

            var basket = this.mapper.Map<BasketViewModel>(model);
            var links = this.linkFactory.Create(basket, Url);
            basket.Links = links;

            return Ok(basket);
        }

        /// <summary>
        /// Removes a product from the basket
        /// </summary>
        /// <param name="id">Basket Id</param>
        /// <param name="productId">Product Id to remove</param>
        /// <returns></returns>
        [HttpDelete("{id}/product/{productId}", Name = "RemoveProductFromBasket")]
        public async Task<IActionResult> Remove(int id, int productId)
        {
            var dto = new RemoveProductFromBasketServiceDto(id, productId); 
            var model = await this.removeProductFromBasketService.Execute(dto);

            var basket = this.mapper.Map<BasketViewModel>(model);
            var links = this.linkFactory.Create(basket, Url);
            basket.Links = links;

            return Ok(basket);
        }
    }
}
