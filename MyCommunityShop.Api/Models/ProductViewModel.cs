namespace MyCommunityShop.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel : ViewModelBase
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
