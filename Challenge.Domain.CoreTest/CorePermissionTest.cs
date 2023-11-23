using Bogus;
using Challenge.Domain.core.Aggregates.PermissionAggregate;
using FluentAssertions;
using Xunit;

namespace Challenge.Domain.CoreTest
{
    public class CorePermissionTest
    {

        Faker<Permission> _permisson;

        public CorePermissionTest()
        {
            _permisson = new Faker<Permission>()
                .RuleFor(x => x.Id, x => x.Random.Guid())
                .RuleFor(x => x.EmployeeForename, x => x.Random.String())
                .RuleFor(x => x.EmployeeSurname, x => x.Random.String())
                .RuleFor(x => x.PermissionType, x => x.Random.Number(1, 2))
                .RuleFor(x => x.PermissionDate, x => x.Date.Recent(1000));
        }

        [Fact]
        public void VerifyCorrectCreationOfPermission()
        {
            //Arrange
            var permission1 = _permisson.Generate();
            //Act
            var permission = new Permission(permission1.EmployeeForename, permission1.EmployeeSurname, permission1.PermissionType, permission1.PermissionDate);
            //Assert
            permission1.Should().BeEquivalentTo(permission);
        }
    } 
}
