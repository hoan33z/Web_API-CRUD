using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhBmi : ControllerBase
    {
        [HttpGet("Tinh-bmi")]
        public double CalculateBMI(double weight, double height)
        {
            return weight / (height * height);
        }
    }
}
