using WVBApp.Shared.Entities;

namespace WVBApp.Shared.DTOs
{
    public class PreferredDaysPackage
    {
        public List<MemberPreferredDays>? DeleteDays { get; set; } = new List<MemberPreferredDays>();
        public List<MemberPreferredDays>? AddDays { get; set; } = new List<MemberPreferredDays>();
    }
}
