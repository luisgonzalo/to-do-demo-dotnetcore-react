using NUnit.Framework;
using PerfectChannel.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Test.TodoServiceTests
{
    [TestFixture]
    public class GetItemsTests
    {
        private TodoService _todoService;

        [SetUp]
        protected void SetUp()
        {
            _todoService = new TodoService();
        }

        [TearDown]
        protected void TearDown()
        {
            _todoService.ClearList();
        }

        [Test]
        public async Task WhenTodoListCreated_GivenNothingAdded_ThenResultIsAnEmptyList()
        {
            // Arrange
            
            // Act
            var todoList = await _todoService.GetAllTodoItemsAsync();

            // Assert
            Assert.IsNotNull(todoList, "A new todo list cannot be null");
            Assert.IsTrue(todoList.Length == 0, "A new todo list must be empty");
        }

        [Test]
        public async Task WhenATodoItemIsAdded_ThenItemsCountIsIncreasedByOne()
        {
            // Arrange
            
            // Act
            var todoListBeforeAdding = await _todoService.GetAllTodoItemsAsync();
            _todoService.Add(new DataModel.TodoItem { Description = "New" });
            var todoListAfterAdding = await _todoService.GetAllTodoItemsAsync();

            // Assert
            Assert.IsTrue(todoListAfterAdding.Length == todoListBeforeAdding.Length + 1, "A new item must be added");
        }

        [Test]
        public async Task WhenGetTodoItem_GivenTheIdIsNotFound_ThenNullIsReturned()
        {
            // Arrange
            var invalidId = 333;

            // Act
            _todoService.Add(new DataModel.TodoItem { Id = 1, Description = "New" });
            var result = await _todoService.GetTodoItemAsync(invalidId);

            // Assert
            Assert.IsNull(result, "Null must be returned");
        }

        [Test]
        public async Task WhenGetTodoItem_GivenTheIdIsValid_ThenTheItemIsReturned()
        {
            // Arrange
            var validId = 1;

            // Act
            _todoService.Add(new DataModel.TodoItem { Id = 1, Description = "New" });
            var result = await _todoService.GetTodoItemAsync(validId);

            // Assert
            Assert.IsNotNull(result, "Cannot return null");
            Assert.IsTrue(result.Id == validId, "Returned item must have the valid Id");
        }

    }
}
