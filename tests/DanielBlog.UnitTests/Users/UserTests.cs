using DanielBlog.Domain.Users;
using DanielBlog.Domain.Users.ValueObjects;

namespace DanielBlog.UnitTests.Users;

public class UserTests
{
    [Fact]
    public void User_happy_path()
    {
        var user = new User("Daniel",  new Password("Password"));
    }
}
