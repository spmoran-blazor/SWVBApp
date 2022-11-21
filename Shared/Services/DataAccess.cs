using System.Collections.Generic;
using System.Net.Http.Json;
using WVBApp.Shared.Entities;

namespace WVBApp.Shared.Services.Data
{
    public class DataAccessService
    {
        HttpClient _http;
        private string? _baseUrl;

        public DataAccessService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("DataAccessHttpClient");
        }

        #region "MemberData"

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

        public async Task<Member?> GetMemberById(int Id)
        {
            SetBaseUri();
            Member member = new Member();

            var response = await _http.GetAsync($"{_baseUrl}api/getmemberbyid/{Id}");
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

        #endregion

        #region "EventData"

        public async Task<IEnumerable<EventSchedulingCode>?> GetEventSchedulingCodes()
        {
            SetBaseUri();
            IEnumerable<EventSchedulingCode>? codes = new List<EventSchedulingCode>();   

            var response = await _http.GetAsync($"{_baseUrl}api/geteventschedulingcodes");
            codes = await response.Content.ReadFromJsonAsync<IEnumerable<EventSchedulingCode>?>() ?? null;

            return codes ?? null;
        }
        #endregion

        #region "MessageData"
        public async Task<IEnumerable<Message>?> GetMessages()
        {
            SetBaseUri();
            IEnumerable<Message>? messages = new List<Message>();

            var response = await _http.GetAsync($"{_baseUrl}api/getmessages");
            messages = await response.Content.ReadFromJsonAsync<IEnumerable<Message>?>() ?? null;

            return messages ?? null;
        }

        #endregion

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
        public Task<Member?> GetMemberById(int Id);
        public Task<IEnumerable<MemberExceptionDates>?> GetMemberExceptionDates(int Id);
        public Task<IEnumerable<PlayDay>?> GetMemberPreferredDaysById(int Id);
    }

}
