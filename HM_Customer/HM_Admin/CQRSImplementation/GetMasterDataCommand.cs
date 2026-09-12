using HM_Admin.Models;
using HM_Admin.Repositorys.IRepository;
using MediatR;

namespace HM_Admin.CQRSImplementation
{
    public class GetMasterDataCommand ():IRequest<IEnumerable<Countries>>
    {
    }
    public class GetMasterDataCommandHandler : IRequestHandler<GetMasterDataCommand, IEnumerable<Countries>>
    {
        private readonly IGetMasterDataRepository _repository;
        public GetMasterDataCommandHandler(IGetMasterDataRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Countries>> Handle(GetMasterDataCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllCountry();
        }
    }
}
