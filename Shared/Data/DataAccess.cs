using System.Net.Http.Json;
using WVBApp.Shared.Entities;

//using static System.Net.WebRequestMethods;

namespace WVBApp.Shared.Data
{
    public class DataAccessService : IDataAccessService
    {
        HttpClient _http;
        private string? _baseUrl;

        public DataAccessService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("DataAccessHttpClient");
        }

        public async Task<Member?> GetMemberByEmail(string email)
        {
            SetBaseUri();
            Member member = new Member();

            var response = await _http.GetAsync($"{_baseUrl}api/getmemberbyemail/{email}");
            var members = await response.Content.ReadFromJsonAsync<IEnumerable<Member>>() ?? null;

            if (members != null)
            {
                if (members.Count() > 0)
                {
                    member = members.FirstOrDefault();
                }
            }

            return member ?? null;
        }

        private void SetBaseUri()
        {
            _baseUrl = "https://swvbsa.azurewebsites.net/";
#if DEBUG
            _baseUrl = "http://localhost:7289/";
#endif

        }
    }

    public interface IDataAccessService
    {
        public Task<Member?> GetMemberByEmail(string email);
    }

}
