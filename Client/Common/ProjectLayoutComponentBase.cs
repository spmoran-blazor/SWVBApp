//using Blazored.SessionStorage;
//using Client.Shared;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Authorization;
//using System;
//using System.Security.Claims;
//using WVBApp.Shared.Data;
//using WVBApp.Shared.Entities;

//namespace WVBApp.Client.Common
//{


//    public class ProjectLayoutComponentBase : LayoutComponentBase
//    {
//        public AuthenticationStateProvider _authenticationStateProvider;
//        public DataAccessService? _data;
//        public Member _currentMember = new Member();
//        public ClaimsPrincipal? _user;
//        public int _userId;
//        public string? _userEmail;
//        public string? _userName;
//        public bool _isLoaded = false;
//        [Inject]
//        ISessionStorageService SessionStorage { get; set; }

//        public ProjectLayoutComponentBase(
//            AuthenticationStateProvider authenticationStateProvider,
//            DataAccessService dataAccess)
//        {
//            _data = dataAccess;
//            _authenticationStateProvider = authenticationStateProvider;
//            GetClaimsPrincipalData().RunSynchronously();
//            GetMemberByEmail().RunSynchronously();

//        }

//        private async Task GetClaimsPrincipalData()
//        {
//            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
//            var user = authState.User ?? null;

//            if (user is not null && user.Identity is not null)
//            {
//                if (user.Identity.IsAuthenticated)
//                {
//                    _userEmail = user.Identity.Name;
//                }
//            }
//        }

//        private async Task GetMemberByEmail()
//        {
//            _currentMember = await _data.GetMemberByEmail(_userEmail);
//            _userName = $"{_currentMember.FirstName} {_currentMember.LastName}";
//            //await Task.Delay(1000);

//            //var jsonMember = JsonSerializer.Serialize(_currentMember);

//            //await sessionStorage.SetItemAsync("currentUser", jsonMember);
//            //await sessionStorage.SetItemAsync("userName", _userName);
//            //await sessionStorage.SetItemAsync("email", _currentMember.Email);
//            //await sessionStorage.SetItemAsync("userId", _currentMember.Id.ToString());

//            //var foo = JsonSerializer.Deserialize<entities.Member>(await sessionStorage.GetItemAsync<string>("currentUser"));
//            //_userName = await sessionStorage.GetItemAsync<string>("userName");
//            //_userEmail = await sessionStorage.GetItemAsync<string>("email");
//            //_userId = Convert.ToInt32(await sessionStorage.GetItemAsync<string>("userId"));

//            _isLoaded = true;
//        }

//    }
//}
