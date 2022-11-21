using WVBApp.Shared.Entities;
namespace WVBApp.Shared.Services.State
{
    public class StateAccessService
    {
        public StateAccessService()
        {

        }
        public event Action? OnStateChange;

        public Member? Member { get; set; }
        public string? Value { get; set; }
        public string? UserJson { get; set; }
        public string? UserEmail { get; set; }
        public string? UserName { get; set;}
        public string? UserId { get; set;}

        public void SetUserIdValue(string value)
        {
            UserId = value;
            NotifyStateChanged();
            //OnStateChange?.Invoke();
        }
        public void SetMemberValue(Member? value)
        {
            Member = value;
            NotifyStateChanged();
            //OnStateChange?.Invoke();
        }

        public void SetUserJsonValue(string value)
        {
            UserJson = value;
            NotifyStateChanged();
            //OnStateChange?.Invoke();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }

    public interface IStateAccessService
    {
        event Action? OnStateChange;
        string? Value { get; set; }
        string? UserJson { get; set; }
        string? UserEmail { get; set; }
        string? UserName { get; set; }
        string? UserId { get; set; }
        void SetUserIdValue(string value);
        void SetUserJsonValue(string value);
    }
}
