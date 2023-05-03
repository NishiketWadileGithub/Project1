using MegaMinds_WebApp.Models;

namespace MegaMinds_WebApp.Repositories
{
    public interface IStateRepository
    {
        public IEnumerable<StateModel> GetAllStates();
        public StateModel GetStateById(int id);
    }
}
