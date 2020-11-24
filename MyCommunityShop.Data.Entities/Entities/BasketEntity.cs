using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCommunityShop.Data.Entities.Entities
{
    public class BasketEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<BasketItemEntity> BasketItems { get; set; } = new List<BasketItemEntity>();
    }
}
