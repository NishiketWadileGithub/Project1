using MegaMinds_WebApp.Data;
using MegaMinds_WebApp.Models;

namespace MegaMinds_WebApp.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CityModel> GetAllCities()
        {
            return _context.Cities.ToList();
        }

        public CityModel GetCityById(int id)
        {
            return _context.Cities.Select(c => new CityModel { Id = c.Id, CityName = c.CityName }).ToList().FirstOrDefault(c => c.Id == id);
        }

        public List<CityModel> GetCitiesByStateId(int stateId)
        {
            var cities = _context.Cities

                .Where(c => c.StateId == stateId)
                .Select(c => new CityModel
                {
                    Id = c.Id,
                    CityName = c.CityName
                })
                .ToList();

            return cities;
        }
    }
}
