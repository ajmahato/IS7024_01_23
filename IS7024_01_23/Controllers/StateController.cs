using Microsoft.AspNetCore.Mvc;

namespace IS7024_01_23.Controllers
{
    public class StateController : Controller
    {
        [HttpGet]
        [Produces("application/json")]
        public IList<StateDataModel> Get()
        {
            return StateRepository.allStates;
        }

        [HttpGet("{code}")]
        [Produces("application/json")]
        public List<StateDataModel> Get(string code)
        {
            return StateRepository.allStates.ToList();
        }


    }
}
