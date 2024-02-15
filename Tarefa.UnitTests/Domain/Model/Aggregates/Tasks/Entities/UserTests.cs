using Tarefa.Domain.Model.Aggregates.Tasks.Entities;
using Xunit;

public class UserTests
{
    [Fact]
    public void UserId_SetAndGetCorrectly()
    {
        var user = new User();
        var expectedUserId = "456";

        user.UserId = expectedUserId;
        var actualUserId = user.UserId;

        Assert.Equal(expectedUserId, actualUserId);
    }

    [Fact]
    public void Name_SetAndGetCorrectly()
    {
        var user = new User();
        var expectedName = "John Doe";

        user.Name = expectedName;
        var actualName = user.Name;

        Assert.Equal(expectedName, actualName);
    }

}
