using Microsoft.AspNetCore.Mvc;

namespace FakeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "timeout")]
        public async Task<IActionResult> GetTimeOut()
        {
            var timeout = TimeSpan.FromSeconds(10);
            var task = LongRuningOperation();

            if(await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                return Ok("Success");
            }
            else
            {
                return StatusCode(StatusCodes.Status408RequestTimeout);
            }
        }

        private async Task LongRuningOperation()
        {
            await Task.Delay(TimeSpan.FromSeconds(30));
        }
    }
}
