using HM_Admin.Models;
using HM_Admin.Repositorys.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace HM_Admin.Repositorys.Repository
{
    public class GetMasterDataRepository : IGetMasterDataRepository
    {
        private readonly HMAdminDBContext _context;

        public GetMasterDataRepository(HMAdminDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Countries>> GetAllCountry()
        {
            var allcountries = from country in _context.Country
                               join state in _context.State
                                        on country.Id equals state.CountryId into countryStates
                               from state in countryStates.DefaultIfEmpty()
                               join city in _context.City
                                        on state.Id equals city.StateId into stateCity
                               from city in stateCity.DefaultIfEmpty()
                               select new Countries
                               {
                                   Id = country.Id,
                                   Name = country.Name,
                                   Code = country.Code,
                                   State = state != null ? new List<States> {
                                          new States
                                          {
                                              Id = state.Id,
                                              Name = state.Name,
                                              StateCode = state.StateCode,
                                              CountryId = state.CountryId,
                                              //Country = state.Country,
                                             City = city != null ? new List<Cities> { city } : new List<Cities>()
                                          }
                                   } : new List<States>()


                               };

            //var allcountries = _context.Country
            //    .Include(c => c.State)
            //        .ThenInclude(s => s.City);

            var result = await allcountries.ToArrayAsync();
            return result;
        }
    }
}
