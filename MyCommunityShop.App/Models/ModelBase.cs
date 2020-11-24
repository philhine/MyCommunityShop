namespace MyCommunityShop.App.Models
{
    using System.Collections.Generic;

    public abstract class ModelBase
    {
        public IEnumerable<LinkDto> Links { get; set; }
    }
}
