namespace MyCommunityShop.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MyCommunityShop.Api.Interfaces;
    using MyCommunityShop.Api.Models;
    using MyCommunityShop.Domain.Interfaces;
    using MyCommunityShop.Domain.Models;

    /// <summary>
    /// The product resource
    /// </summary>
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IService<IEnumerable<Product>> getProductsService;
        private readonly IMapper mapper;
        private readonly ILinkFactory<ProductViewModel> linkFactory;
        private readonly IService<int, Product> getProductByIdService;

        public ProductsController(
            IService<IEnumerable<Product>> getProductsService, 
            IMapper mapper, 
            ILinkFactory<ProductViewModel> linkFactory,
            IService<int, Product> getProductByIdService)
        {
            this.getProductsService = getProductsService ?? throw new System.ArgumentNullException(nameof(getProductsService));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            this.linkFactory = linkFactory ?? throw new System.ArgumentNullException(nameof(linkFactory));
            this.getProductByIdService = getProductByIdService ?? throw new System.ArgumentNullException(nameof(getProductByIdService));
        }

        // GET: api/<ProductController>
        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
            var response = await this.getProductsService.Execute();

            var products = this.mapper.Map<IEnumerable<ProductViewModel>>(response);
            foreach (var product in products)
            {
                product.Links = this.linkFactory.Create(product, Url);
            }

            return Ok(products);
        }

        //// GET api/<ProductController>/5
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await this.getProductByIdService.Execute(id);

            var product = this.mapper.Map<ProductViewModel>(response);
            product.Links = this.linkFactory.Create(product, Url);

            return Ok(product);
        }
    }
}
