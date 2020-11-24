using System.Collections.Generic;

namespace MyCommunityShop.Api.Models
{
    public abstract class ViewModelBase
    {
        public IEnumerable<LinkDto> Links { get; set; }
    }
}
