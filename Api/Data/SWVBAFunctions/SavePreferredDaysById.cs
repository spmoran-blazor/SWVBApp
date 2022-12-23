using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WVBApp.Shared.Entities;

namespace Api.Data.SWVBAFunctions
{
    //public class SavePreferredDaysById
    //{
    //    private SWVBADbContext _dbContext;

    //    public SavePreferredDaysById(SWVBADbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    [FunctionName("SavePreferredDaysById")]
    //    public async Task<IActionResult> Run(
    //        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "savepreferreddaysbyid/{memberId}")] HttpRequest req,
    //        int MemberId, ILogger log)
    //    {
    //        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

    //        var requestBody = new StreamReader(req.Body).ReadToEndAsync();
    //        var data = requestBody.Result;

    //        MemberPreferredDays memberpfd = JsonSerializer.Deserialize<MemberPreferredDays>(data, options);
    //        if (memberpfd.Id == 0)
    //        {
    //            _dbContext.Add<MemberPreferredDays>(memberpfd);
    //        }
    //        else
    //        {
    //            if (memberpfd.Id > 0)
    //            {
    //                _dbContext.Update<MemberPreferredDays>(memberpfd);
    //            }
    //        }

    //        await _dbContext.SaveChangesAsync();

    //        return new OkObjectResult(member);
    //    }
    //}
}