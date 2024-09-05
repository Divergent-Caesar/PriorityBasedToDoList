using Microsoft.AspNetCore.Mvc;
using Backend.Services;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyController : ControllerBase
    {
        private readonly IMyService _myService;

        public MyController(IMyService myService)
        {
            _myService = myService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _myService.GetDataAsync();
            return Ok(data);
        }
    }
}