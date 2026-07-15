using HM_Admin.Models;
using HM_Admin.Repositorys.IRepository;
using MediatR;

namespace HM_Admin.CQRSImplementation
{
    public record  CreateAdminUserCommand (AdminUser AdminUser) : IRequest<AdminUser>
    {
    }
    public class CreateAdminUserCommandHandler : IRequestHandler<CreateAdminUserCommand, AdminUser>
    {
       
        private readonly IAdminUserRepository _repository;
        public CreateAdminUserCommandHandler(IAdminUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<AdminUser> Handle(CreateAdminUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateAdminUser(request.AdminUser);
        }
    }

    public record GetAllAdminUsersQuery() : IRequest<IEnumerable<AdminUser>>;

    // 2. Define the Query Handler
    public class GetAllAdminUsersQueryHandler : IRequestHandler<GetAllAdminUsersQuery, IEnumerable<AdminUser>>
    {
        private readonly IAdminUserRepository _repository;

        public GetAllAdminUsersQueryHandler(IAdminUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AdminUser>> Handle(GetAllAdminUsersQuery request, CancellationToken cancellationToken)
        {
            // Call your repository method here safely
            return await _repository.GetAllUser();
        }
    }
}
