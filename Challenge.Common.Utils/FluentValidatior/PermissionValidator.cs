using Challenge.Application.Dtos.Permission;
using FluentValidation;

namespace Challenge.Common.Utils.FluentValidatior
{
    public class PermissionValidator : AbstractValidator <Permissiondto>
    {
        public PermissionValidator()
        {
            RuleFor(permissiondto => permissiondto.EmployeeForename).NotEmpty().WithMessage("EmployeeForename is required");
            RuleFor(permissiondto => permissiondto.EmployeeSurname).NotEmpty().WithMessage("EmployeeSurname is required");
        }
    }
}
