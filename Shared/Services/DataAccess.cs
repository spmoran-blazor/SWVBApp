using Microsoft.Data.SqlClient;
using System.Data;
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
            _baseUrl = SetBaseUri();
        }

        #region "MemberData"

        public async Task<Member?> GetMemberByEmail(string email)
        {
            Member? member = new Member();

            var response = await _http.GetAsync($"{_baseUrl}api/getmemberbyemail/{email}");
            member = await response.Content.ReadFromJsonAsync<Member>() ?? null;

            return member ?? null;
        }

        public async Task<Member?> GetMemberById(int Id)
        {
            Member? member = new Member();

            var response = await _http.GetAsync($"{_baseUrl}api/getmemberbyid/{Id}");
            member = await response.Content.ReadFromJsonAsync<Member>() ?? null;

            return member ?? null;
        }

        public async Task<IEnumerable<MemberExceptionDate>?> GetMemberExceptionDatesById(int Id)
        {
            IEnumerable<MemberExceptionDate>? memberExceptionDates;

            var response = await _http.GetAsync($"{_baseUrl}api/GetMemberExceptionDatesById/{Id}");
            memberExceptionDates = await response.Content.ReadFromJsonAsync<IEnumerable<MemberExceptionDate>>() ?? null;

            return memberExceptionDates;
        }

        public async Task<IEnumerable<Entities.MemberPreferredDays>?> GetMemberPreferredDaysById(int Id)
        {
            IEnumerable<Entities.MemberPreferredDays>? memberPreferredDays;

            var response = await _http.GetAsync($"{_baseUrl}api/getgemberpreferreddaysbyid/{Id}");
            memberPreferredDays = await response.Content.ReadFromJsonAsync<IEnumerable<Entities.MemberPreferredDays>>() ?? null;

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
            IEnumerable<Message>? messages = new List<Message>();

            var response = await _http.GetAsync($"{_baseUrl}api/getmessages");
            messages = await response.Content.ReadFromJsonAsync<IEnumerable<Message>?>() ?? null;

            return messages ?? null;
        }

        #endregion

        private string SetBaseUri()
        {
            string retval = string.Empty;
            retval = "https://swvbsa.azurewebsites.net/";
#if DEBUG
            retval = "http://localhost:7289/";
#endif
            return retval;
        }
    }

    public class DatabaseConfig
    {
        public string? ConnectionString { get; set; }
    }


    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection(string connectionString);
    }


}
