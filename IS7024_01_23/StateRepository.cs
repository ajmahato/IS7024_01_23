using IS7024_01_23;

namespace IS7024_01_23
{
    public class StateRepository
    {
        static StateRepository()
        {
            allStates = new List<StateDataModel>();
        }

        public static IList<StateDataModel> allStates { get; set; }
    }
}
