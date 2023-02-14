using Microsoft.AspNetCore.Mvc;
using ozProject.Models;

namespace ozProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class languageController : ControllerBase
    {
        private static readonly IEnumerable<language> Languages = new[]
        {
            new language { Id = "1", Name = "Java" },
            new language { Id = "2",  Name = "C#" }



        };



        [HttpGet]
        public language[] Get()
        {
            language[] languages = Languages.ToArray();
            return languages;
        }
    }
}
