using Challenge.Application.Dtos.Permission;
using Challenge.Application.Services.PaginationServices;


namespace Challenge.Application.Services.Contracs
{
    public interface IPermissionApplicationService
    {
        public IDictionary<string, string> _message { get; set; } 
        Task<bool> addPermission(Permissiondto permissiondto);
        Task<(List<Permissiondto>, Metadata)> getAllPermission(QueryFilter filter);
        Task<bool> ModifyPermission(Permissiondto permissiondto);
        Task<Permissiondto> getByPermission(Guid Id);
    }
}
