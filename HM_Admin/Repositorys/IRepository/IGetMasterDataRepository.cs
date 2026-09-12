using HM_Admin.Models;

namespace HM_Admin.Repositorys.IRepository
{
    public interface IGetMasterDataRepository
    {
        public Task<IEnumerable<Countries>> GetAllCountry();
    }
}
