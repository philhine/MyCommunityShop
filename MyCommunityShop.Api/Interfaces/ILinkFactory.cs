namespace MyCommunityShop.Api.Interfaces
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MyCommunityShop.Api.Models;

    public interface ILinkFactory<TModel>
    {
        IEnumerable<LinkDto> Create(TModel model, IUrlHelper urlHelper);
    }
}
