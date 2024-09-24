using System.Data;
using Dapper;
using Moq;
using toDo.Interfaces;
using toDo.Models;
using toDo.Services;
using Xunit;

namespace toDo.Tests
{
    public class CloseTaskServiceTests
    {
        // private readonly Mock<IDapperDBConnectInterface> _mockDbConnect;
        private readonly closeTaskService _closeTaskService;
        private readonly Mock<IDapperDBConnectInterface> _mockDbConnect;
        private readonly openTaskService _openTaskService;
        private readonly insertNewTaskService _insertNewTaskService;
        public CloseTaskServiceTests()
        {
            _mockDbConnect = new Mock<IDapperDBConnectInterface>();
            _openTaskService = new openTaskService(_mockDbConnect.Object);
            _closeTaskService = new closeTaskService(_mockDbConnect.Object);
            _insertNewTaskService = new insertNewTaskService(_mockDbConnect.Object);

        }

        [Fact]
        public void CloseTask_Should_Return_Task_Closed()
        {
            // Arrange
            int taskNumber = 123;
            string expectedQuery = $"UPDATE [dbo].[NewTable] SET Status = 'Done' where TaskNumber = {taskNumber}";
            _mockDbConnect.Setup(db => db.PostDBQuery(expectedQuery)).Returns("Query Executed");

            // Act
            var result = _closeTaskService.closeTask(taskNumber);

            // Assert
            Assert.Equal("Task Closed", result);
            _mockDbConnect.Verify(db => db.PostDBQuery(expectedQuery), Times.Once);
        }
        
        [Fact]
        public void InsertNewTask_ReturnsConfirmationMessage()
        {
            // Arrange
            string taskName = "New Task";
            string taskDescription = "This is a new task description.";
            DateOnly dueDate = new DateOnly(2024, 12, 31);

            // Mock the PostDBQuery method to return a success message or an empty string
            _mockDbConnect.Setup(db => db.PostDBQuery(It.IsAny<string>())).Returns(string.Empty);

            // Act
            var result = _insertNewTaskService.insertNewTask(taskName, taskDescription, dueDate);

            // Assert
            Assert.Equal("Task inserted", result);
            _mockDbConnect.Verify(db => db.PostDBQuery(It.IsAny<string>()), Times.Once);
            
        }
        [Fact]
        public void InsertNewTask_CallsDatabaseWithCorrectQuery()
        {
            // Arrange
            string taskName = "New Task";
            string taskDescription = "This is a new task description.";
            DateOnly dueDate = new DateOnly(2024, 12, 31);

            // Mock the PostDBQuery method to return an empty string or a success message
            _mockDbConnect.Setup(db => db.PostDBQuery(It.IsAny<string>())).Returns(string.Empty);

            // Act
            _insertNewTaskService.insertNewTask(taskName, taskDescription, dueDate);

            // Assert
            _mockDbConnect.Verify(db => db.PostDBQuery(
                $"insert into [dbo].[NewTable] (TaskName,[Desc],DueDate, Status) values ('{taskName}','{taskDescription}', '2024-12-31','New')"), 
                Times.Once);
        }
        [Fact]
        public void OpenTask_ThrowsInvalidOperationException_WhenConnectionIsNull()
        {
            // Arrange
            _mockDbConnect.Setup(db => db.CreateConnection()).Returns((IDbConnection)null);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => _openTaskService.OpenTask());
            Assert.Equal("Database connection could not be created.", exception.Message);
        }
    }
}
