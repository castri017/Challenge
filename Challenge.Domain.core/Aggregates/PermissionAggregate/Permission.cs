using Challenge.Domain.core.SeedWork;

namespace Challenge.Domain.core.Aggregates.PermissionAggregate
{
    public class Permission : Entity, IAggregateRoot
    {


        public string EmployeeForename { get; private set; }
        public string EmployeeSurname { get; private set; }
        public int PermissionType { get; private set; }
        public DateTime PermissionDate { get; private set; }

        public Permission(string EmployeeForename, string EmployeeSurname, int PermissionType, DateTime PermissionDate)
        {
            Id = Guid.NewGuid();
            this.EmployeeForename = EmployeeForename;
            this.EmployeeSurname = EmployeeSurname;
            this.PermissionType = PermissionType;
            this.PermissionDate = PermissionDate;
        }


        public void setValuePermission(Permission permission)
        {
            EmployeeForename = permission.EmployeeForename;
            EmployeeSurname = permission.EmployeeSurname;
            PermissionType = permission.PermissionType;
            PermissionDate = permission.PermissionDate;
        }

    }
}
