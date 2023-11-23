using AutoMapper;
using Challenge.Application.Dtos.Permission;
using Challenge.Application.Services.Contracs;
using Challenge.Application.Services.PaginationServices;
using Challenge.Application.Services.Services;
using Challenge.Common.Exceptions.Exceptions;
using Challenge.Domain.core.Aggregates.PermissionAggregate;
using Challenge.Domain.core.SeedWork;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Nest;

namespace Challenge.Application.Services
{
    public class PermissionApplicationService : IPermissionApplicationService
    {
        private readonly IUnitofWorkChallenge _unitofWorkChallenge;
        private readonly IValidator<Permissiondto> _permissionValidator;
        private readonly IConfiguration _configuration;
        private readonly IMapper _maper;
        private readonly IElasticClient _elasticClient;

        public IDictionary<string, string> _message { get; set; }

        public PermissionApplicationService
       (
           IUnitofWorkChallenge _unitofWorkChallenge,
           IValidator<Permissiondto> _permissionValidator, 
           IConfiguration _configuration,
           IMapper _maper

       )
        {
            this._unitofWorkChallenge = _unitofWorkChallenge; 
            this._permissionValidator = _permissionValidator;
            this._configuration = _configuration;
            this._maper = _maper;
        }


        public async Task<bool> addPermission(Permissiondto permissiondto)
        {
            var result = await _permissionValidator.ValidateAsync(permissiondto);
            if(!result.IsValid)
                throw new ApiException(400, result.ToString(", "));

            var permission = _maper.Map<Permission>(permissiondto);
            var (iscreated, newStaffing) = await _unitofWorkChallenge.permissionRepository.addPermission(permission);
            return iscreated;
        }

        public async Task<(List<Permissiondto>, Metadata)> getAllPermission(QueryFilter filter)
        {
            var _permission= await _unitofWorkChallenge.permissionRepository.getAllPermission();
            if (_permission.hasNoRecords()) throw new ApiException(404, _message["notFoundPermission"]);
            var permissions = PagedList<Permission>.create(_permission, filter.PageNumber, filter.PageSize);
            var meta = Metadata.create(permissions.CurrentPage, permissions.TotalPages, permissions.PageSize, permissions.TotalAcount, permissions.HasPreviusPage, permissions.HasNextPage);
            var permissiondto = _maper.Map<List<Permissiondto>>(permissions);
            return (permissiondto, meta);
        }

        public async Task<bool> ModifyPermission(Permissiondto permisiondto)
        {
            var result = await _permissionValidator.ValidateAsync(permisiondto);

            if (!result.IsValid)
                throw new ApiException(400, result.ToString(", "));
             
            var existsSataffing = await _unitofWorkChallenge.permissionRepository.existsPermission(permisiondto.Id);
            if (!existsSataffing)
                throw new ApiException(202, _message["notExistsPermission"]);

            var permission = _maper.Map<Permission>(permisiondto);
            var (isupdated, newpermission) = await _unitofWorkChallenge.permissionRepository.ModifyPermission(permission);

            return isupdated;
        }

        public  async Task<Permissiondto> getByPermission(Guid Id)
        {
            var permission = await _unitofWorkChallenge.permissionRepository.getByIdPermission(Id);
            if (permission.hasNoRecords()) throw new ApiException(404, _message["notFoundPermission"]);
            var permissiondto = _maper.Map<Permissiondto>(permission);
            return permissiondto;
        }
 
    }
}
