using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVBApp.Shared.Entities
{
    public  class PreferredPlayDays
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int DayOfWeekId { get; set; }
        public bool IsPreferred { get; set; }
        public string Day { get; set; }
    }
}
