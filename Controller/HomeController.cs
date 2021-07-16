using ChatEkoSystem.Business;
using ChatEkoSystem.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatEkoSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController] 
 
    public class HomeController : ControllerBase
    {
         readonly MyBusiness _myBusiness;
        readonly IHubContext<MyHub> _hubContext;
        public HomeController(MyBusiness myBusiness,IHubContext<MyHub> hubContext)
        {
            _myBusiness = myBusiness;
            _hubContext = hubContext; 
        }
        [HttpGet("message")]
        public async Task<IActionResult> Index(string message)
        {
           await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}
