using Microsoft.AspNetCore.Mvc;

namespace Cliente.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
      
        public ClienteController()
        {
        }

        [HttpPost]
        public bool Post()
        {
            return true;
        }
    }
}
