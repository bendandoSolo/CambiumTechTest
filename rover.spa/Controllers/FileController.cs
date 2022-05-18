using Microsoft.AspNetCore.Mvc;

namespace rover.spa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult<object> Post(IFormFile file)
        {
            List<string> RoverCommands = new List<string>();
            
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string row;
                while ((row = reader.ReadLine()) != null)
                {
                    RoverCommands.Add(row);
                }
            }

            //NB: could return RoverCommands as well as part of instructions data
            return Ok(RoverCommands);
        }


    }
}
