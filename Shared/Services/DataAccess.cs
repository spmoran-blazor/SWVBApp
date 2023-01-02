using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using WVBApp.Shared.DTOs;
using WVBApp.Shared.Entities;

namespace WVBApp.Shared.Services.Data
{
    public partial class DataAccessService
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
            member = await response.Content.ReadFromJsonAsync<Member>();

            return member ?? null;
        }

        public async Task<Member?> GetMemberById(int Id)
        {
            Member? member = new Member();

            var response = await _http.GetAsync($"{_baseUrl}api/getmemberbyid/{Id}");
            member = await response.Content.ReadFromJsonAsync<Member>();

            return member ?? null;
        }

        public async Task<IEnumerable<MemberExceptionDate>?> GetMemberExceptionDatesById(int Id)
        {
            IEnumerable<MemberExceptionDate>? memberExceptionDates;

            var response = await _http.GetAsync($"{_baseUrl}api/GetMemberExceptionDatesById/{Id}");
            memberExceptionDates = await response.Content.ReadFromJsonAsync<IEnumerable<MemberExceptionDate>>();

            return memberExceptionDates;
        }

        public async Task<IEnumerable<Entities.MemberPreferredDays>?> GetMemberPreferredDaysById(int Id)
        {
            IEnumerable<Entities.MemberPreferredDays>? memberPreferredDays;

            var response = await _http.GetAsync($"{_baseUrl}api/getmemberpreferreddaysbyid/{Id}");
            memberPreferredDays = await response.Content.ReadFromJsonAsync<IEnumerable<Entities.MemberPreferredDays>>();

            return memberPreferredDays;
        }

        public async Task<Member?> SaveMember(Member member)
        {
            JsonContent memberString = JsonContent.Create<Member>(member);
            var response = await _http.PostAsync($"{_baseUrl}api/savemember", memberString);
            var retval = await response.Content.ReadFromJsonAsync<Member>();
            return retval;
        }

        public async Task<MemberExceptionDate?> SaveExceptionDate(MemberExceptionDate mxd)
        {
            JsonContent valueString = JsonContent.Create<MemberExceptionDate>(mxd);
            var response = await _http.PostAsync($"{_baseUrl}api/saveexceptiondate", valueString);
            var retval = await response.Content.ReadFromJsonAsync<MemberExceptionDate>();
            return retval;
        }

        public async Task<List<MemberPreferredDays>> SavePreferredDays(PreferredDaysPackage days)
        {
            JsonContent incoming = JsonContent.Create<PreferredDaysPackage>(days);
            var response = await _http.PostAsync($"{_baseUrl}api/savepreferreddays", incoming);
            var retval = await response.Content.ReadFromJsonAsync<List<MemberPreferredDays>>();
            return retval;
        }

        public async Task<bool> RemoveExceptionDate(MemberExceptionDate date)
        {
            JsonContent incoming = JsonContent.Create<MemberExceptionDate>(date);
            var response = await _http.PostAsync($"{_baseUrl}api/deleteexceptiondate", incoming);
            return response.IsSuccessStatusCode;
        }
        #endregion

        #region "EventData"

        public async Task<bool> DeleteEvent(Event evt)
        {
            JsonContent incoming = JsonContent.Create<Event>(evt);
            var response = await _http.PostAsync($"{_baseUrl}api/deleteevent", incoming);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<EventSchedulingCode>?> GetEventSchedulingCodes()
        {
            SetBaseUri();
            IEnumerable<EventSchedulingCode>? codes = new List<EventSchedulingCode>();

            var response = await _http.GetAsync($"{_baseUrl}api/geteventschedulingcodes");
            codes = await response.Content.ReadFromJsonAsync<IEnumerable<EventSchedulingCode>?>() ?? null;

            return codes ?? null;
        }

        public async Task<IEnumerable<EventWithCodeInfo>> GetScheduledEvents()
        {
            SetBaseUri();
            IEnumerable<EventWithCodeInfo> codes = new List<EventWithCodeInfo>();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };

            var response = await _http.GetAsync($"{_baseUrl}api/getscheduledevents");

            codes = await response.Content.ReadFromJsonAsync<IEnumerable<EventWithCodeInfo>>(options);

            return codes;
        }

        public async Task<Event?> SaveEvent(Event evt)
        {
            JsonContent memberString = JsonContent.Create<Event>(evt);
            var response = await _http.PostAsync($"{_baseUrl}api/saveevent", memberString);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var retval = await response.Content.ReadFromJsonAsync<Event>();
                    return retval;
                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
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

        public string SetBaseUri()
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


