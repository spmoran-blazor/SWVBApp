using WVBApp.Shared.DTOs;
using WVBApp.Shared.Entities;

namespace WVBApp.Shared.Services.State
{
    public class StateAccessService
    {
        public event Action? OnStateChange;

        public Member? Member { get; set; }
        public string? Value { get; set; }
        public string? UserJson { get; set; }
        public string? UserEmail { get; set; }
        public string? UserName { get; set;}
        public string? UserId { get; set;}
        public EventWithCodeInfo EventWithCodeInfo { get; set; }

        public void SetUserIdValue(string value)
        {
            UserId = value;
            NotifyStateChanged();
        }
        public void SetMemberValue(Member? value)
        {
            Member = value;
            NotifyStateChanged();
        }

        public void SetUserJsonValue(string value)
        {
            UserJson = value;
            NotifyStateChanged();
        }

        public void SetEventWithCodeInfo(EventWithCodeInfo value)
        {
            EventWithCodeInfo = value;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
