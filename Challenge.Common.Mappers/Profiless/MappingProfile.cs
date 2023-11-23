using AutoMapper;
using Challenge.Application.Dtos.Permission;
using Challenge.Domain.core.Aggregates.PermissionAggregate;

namespace Challenge.Common.Mappers.Profiless
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<Permissiondto, Permission >()
                .ForMember(x => x.Id, ops => ops.MapFrom(x => getPermissionGuid(x)))
                .ForMember(x => x.EmployeeForename, ops => ops.MapFrom(x => x.EmployeeForename))
                .ForMember(x => x.EmployeeSurname, ops => ops.MapFrom(x => x.EmployeeSurname))
                .ForMember(x => x.PermissionType, ops => ops.MapFrom(x => x.PermissionType))
                .ForMember(x => x.PermissionDate, ops => ops.MapFrom(x => x.PermissionDate))
                .ReverseMap(); 
        }

        private Guid getPermissionGuid(Permissiondto permissiondto) => permissiondto.Id == Guid.Empty ? Guid.NewGuid() : permissiondto.Id;
        //private Guid getPermissionTypeGuid(Permissiondto permissiondto) => permissiondto.PermissionType == Guid.Empty ? Guid.NewGuid() : permissiondto.PermissionType;
        private DateTime getPermissionDate(Permissiondto permissiondto) => permissiondto.PermissionDate.Year == 0001 ? DateTime.Now : permissiondto.PermissionDate;
    }
}

