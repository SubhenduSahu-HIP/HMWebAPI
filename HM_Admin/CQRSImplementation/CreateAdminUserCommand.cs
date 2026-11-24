using Azure.Core;
using HM_Admin.Models;
using HM_Admin.Repositorys.IRepository;
using MediatR;

namespace HM_Admin.CQRSImplementation
{
    public record CreateAdminUserCommand(AdminUser AdminUser) : IRequest<AdminUser>
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

    public record GetAllUsers(): IRequest<IEnumerable<AdminUser>>;
    public record GetAllAdminUsers() : IRequest<IEnumerable<AdminUser>>;
    public record GetUserByIdQuery(int Id) : IRequest<IEnumerable<AdminUser>>;

    // 2. Define the Query Handler
    public class GetAllAdminUsersQueryHandler : IRequestHandler<GetAllAdminUsers, IEnumerable<AdminUser>>, IRequestHandler<GetUserByIdQuery, IEnumerable<AdminUser>>, IRequestHandler<GetAllUsers, IEnumerable<AdminUser>>
    {
        private readonly IAdminUserRepository _repository;


        public GetAllAdminUsersQueryHandler(IAdminUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AdminUser>> Handle(GetAllAdminUsers request, CancellationToken cancellationToken)
        {
            // Call your repository method here safely
            return await _repository.GetAllAdminUser();
        }
        public async Task<IEnumerable<AdminUser>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            // Call your other method from IAdminUserRepository
            return await _repository.GetUserById(request.Id);
        }

        public async Task<IEnumerable<AdminUser>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return  await _repository.GetAllUser();
        }
    }

    public record UpdateUserCommand(AdminUser AdminUser) : IRequest<AdminUser>;
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, AdminUser>
    {
        private readonly IAdminUserRepository _repository;

        public UpdateUserCommandHandler(IAdminUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<AdminUser?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateUser(request.AdminUser);
        }

    }
}
