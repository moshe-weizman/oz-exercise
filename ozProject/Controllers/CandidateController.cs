using Microsoft.AspNetCore.Mvc;
using ozProject.Models;

namespace ozProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private static readonly IEnumerable<Candidate> Candidates = new[]
        {
            new Candidate { Id = "1", BeginYear = 1900, Languages =new string[]{"1", "2" }, LastUpdateDate = new DateTime(2020, 2, 14, 10, 30, 0), Name = "Or" },
            new Candidate { Id = "2", BeginYear = 2022, Languages =new string[]{"2" }, LastUpdateDate = new DateTime(2021, 2, 14, 10, 30, 0), Name = "Mosh" },
            new Candidate { Id = "3", BeginYear = 2020, Languages =new string[]{"2" }, LastUpdateDate = new DateTime(1999, 2, 14, 10, 30, 0), Name = "Dan" },
           new Candidate { Id = "4",  Languages =new string[]{"1" }, LastUpdateDate = new DateTime(1998, 2, 14, 10, 30, 0), Name = "David" }



        };

      

        [HttpGet]
        public Candidate[] Get()
        {
            Candidate[] candidates = Candidates.OrderByDescending(x => x.LastUpdateDate).ToArray();
            return candidates;
        }
    }
}
