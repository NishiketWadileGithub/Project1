using MegaMinds_WebApp.Models;

namespace MegaMinds_WebApp.Repositories
{
    public interface ICityRepository
    {
        public IEnumerable<CityModel> GetAllCities();
        public CityModel GetCityById(int id);
        public List<CityModel> GetCitiesByStateId(int stateId);
    }
}
