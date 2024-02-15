using Tarefa.Domain.Model.Aggregates.Tasks.Entities;
using Xunit;
    public class TasksTests
    {
        [Fact]
        public void TaskId_SetAndGetCorrectly()
        {
            var tasks = new Tasks();
            var expectedTaskId = "123";

            tasks.TaskId = expectedTaskId;
            var actualTaskId = tasks.TaskId;

            Assert.Equal(expectedTaskId, actualTaskId);
        }

        [Fact]
        public void User_SetAndGetCorrectly()
        {
            var tasks = new Tasks();
            var expectedUser = new User();

            tasks.User = expectedUser;
            var actualUser = tasks.User;

            Assert.Equal(expectedUser, actualUser);
        }

        [Fact]
        public void Title_SetAndGetCorrectly()
        {
            var tasks = new Tasks();
            var expectedTitle = "Task Title";

            tasks.Title = expectedTitle;
            var actualTitle = tasks.Title;

            Assert.Equal(expectedTitle, actualTitle);
        }

        [Fact]
        public void Description_SetAndGetCorrectly()
        {
            var tasks = new Tasks();
            var expectedDescription = "Task Description";

            tasks.Description = expectedDescription;
            var actualDescription = tasks.Description;

            Assert.Equal(expectedDescription, actualDescription);
        }

        [Fact]
        public void ExpiresAt_SetAndGetCorrectly()
        {
            var tasks = new Tasks();
            var expectedExpiresAt = DateTime.Now;

            tasks.ExpiresAt = expectedExpiresAt;
            var actualExpiresAt = tasks.ExpiresAt;

            Assert.Equal(expectedExpiresAt, actualExpiresAt);
        }

        [Fact]
        public void CreatedAt_SetAndGetCorrectly()
        {
            var tasks = new Tasks();
            var expectedCreatedAt = DateTime.Now;

            tasks.CreatedAt = expectedCreatedAt;
            var actualCreatedAt = tasks.CreatedAt;

            Assert.Equal(expectedCreatedAt, actualCreatedAt);
        }

}