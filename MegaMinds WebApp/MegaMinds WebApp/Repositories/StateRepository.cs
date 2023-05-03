using MegaMinds_WebApp.Data;
using MegaMinds_WebApp.Models;

namespace MegaMinds_WebApp.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _context;

        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<StateModel> GetAllStates()
        {
            return _context.States.Select(s => new StateModel { StateId = s.StateId, StateName = s.StateName }).ToList();

        }

        public StateModel GetStateById(int id)
        {
            return _context.States.Select(s => new StateModel { StateId = s.StateId, StateName = s.StateName }).ToList().FirstOrDefault(s => s.StateId == id);
        }
    }
}
