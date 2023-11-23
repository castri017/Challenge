namespace Challenge.Application.Dtos.Permission
{
    public class Permissiondto
    {
        public Guid Id { get; set; }
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public int PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }
 
    }
}
