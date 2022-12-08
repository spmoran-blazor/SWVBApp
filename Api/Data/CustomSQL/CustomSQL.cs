using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.CustomSQL
{
    public static class CustomSQL
    {
        public static string GetPreferredDaysById(int Id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string retval = string.Empty;

            sb.Append($"SELECT CASE  WHEN mpd.MemberId IS NULL ");
            sb.Append($"THEN 'false' ");
            sb.Append($"ELSE 'true' END AS isPreferred ");
            sb.Append($", ISNULL(mpd.MemberId,{Id}) AS MemberId");
            sb.Append($", dow.Id AS DayOfWeekId, dow.Id, dow.Day ");
            sb.Append($", ISNULL(mpd.UpdateDate, GETDATE()) AS UpdateDate");
            sb.Append($", ISNULL(mpd.UpdatedBy, 'NA') AS UpdatedBy");
            sb.Append($" FROM dbo.DayOfWeek AS dow ");
            sb.Append($"FULL OUTER JOIN dbo.MemberPreferredDays AS mpd ON dow.Id = mpd.DayOfWeekId ");
            sb.Append($"WHERE (mpd.MemberId = {Id}) ");
            sb.Append($"AND (dow.Id IS NULL) OR (NOT (dow.Id IS NULL)) ");

            return sb.ToString();
        }
    }
}
