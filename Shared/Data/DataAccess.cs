using System.Collections.Generic;
using System.Net.Http.Json;
using WVBApp.Shared.Entities;

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

        public async Task<IEnumerable<MemberExceptionDates>?> GetMemberExceptionDates(int Id)
        {
            SetBaseUri();
            IEnumerable<MemberExceptionDates>? memberExceptionDates;

            var response = await _http.GetAsync($"{_baseUrl}api/getmemberexceptiondates/{Id}");
            memberExceptionDates = await response.Content.ReadFromJsonAsync<IEnumerable<MemberExceptionDates>>() ?? null;

            return memberExceptionDates;
        }

        public async Task<IEnumerable<PlayDay>?> GetMemberPreferredDaysById(int Id)
        {
            SetBaseUri();
            IEnumerable<PlayDay>? memberPreferredDays;

            var response = await _http.GetAsync($"{_baseUrl}api/getgemberpreferreddaysbyid/{Id}");
            memberPreferredDays = await response.Content.ReadFromJsonAsync<IEnumerable<PlayDay>>() ?? null;

            return memberPreferredDays;
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
        public Task<IEnumerable<MemberExceptionDates>?> GetMemberExceptionDates(int Id);
    }

}
