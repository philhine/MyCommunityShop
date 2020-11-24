namespace MyCommunityShop.App.Models
{
    public class LinkDto
    {
        public LinkDto()
        {
        }

        public LinkDto(string href, string relativePath, string method)
        {
            this.Href = href;
            this.Rel = relativePath;
            this.Method = method;
        }

        public string Href { get; set; }

        public string Rel { get; set; }

        public string Method { get; set; }

    }
}
