namespace MyCommunityShop.App.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    //todo: re-enable once logging is implemented
    #pragma warning disable CS0168
    public sealed class DataService
    {
        private readonly HttpClient client = new HttpClient();

        public DataService(string baseApiAddress)
        {
            client.BaseAddress = new Uri(baseApiAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> Get<T>(string path)
        {
            try
            {
                var response = await client.GetAsync(path);
                return await HandleResponse<T>(response);
            }
            catch (Exception ex)
            {
                //todo log
                return default;
            }
        }

        public async Task<T> Post<T>(string path)
        {
            try
            {
                var response = await client.PostAsync(path, null);
                return await HandleResponse<T>(response);
            }
            catch (Exception ex)
            {
                //todo log
                return default;
            }
        }

        public async Task<T> Delete<T>(string path)
        {
            try
            {
                var response = await client.DeleteAsync(path);
                return await HandleResponse<T>(response);
            }
            catch (Exception ex)
            {
                //todo log
                return default;
            }
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            T newResource = default(T);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                // log somewhere
            }

            return newResource;
        }
    }
}
