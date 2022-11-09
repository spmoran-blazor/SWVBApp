using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVBApp.Shared.Entities
{
    public class PlayDay
    {
        public int Id { get; set; }
        public bool DayOfWeek { get; set; }
        public string? Day { get; set; }

    }
}
