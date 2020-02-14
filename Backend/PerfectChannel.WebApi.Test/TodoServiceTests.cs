using NUnit.Framework;
using PerfectChannel.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Test
{
    [TestFixture]
    public class TodoServiceTests
    {
        [Test]
        public async Task WhenTodoListCreated_GivenNothingAdded_ThenResultIsAnEmptyList()
        {
            // Arrange
            var todoService = new TodoService();

            // Act
            var todoList = await todoService.GetAllTodoItemsAsync();

            // Assert
            Assert.IsNotNull(todoList, "A new todo list cannot be null");
            Assert.IsTrue(todoList.Length == 0, "A new todo list must be empty");
        }

        [Test]
        public async Task WhenATodoItemIsAdded_ThenItemsCountIsIncreasedByOne()
        {
            // Arrange
            var todoService = new TodoService();

            // Act
            var todoListBeforeAdding = await todoService.GetAllTodoItemsAsync();
            todoService.Add(new DataModel.TodoItem { Description = "New" });
            var todoListAfterAdding = await todoService.GetAllTodoItemsAsync();

            // Assert
            Assert.IsTrue(todoListAfterAdding.Length == todoListBeforeAdding.Length + 1, "A new item must be added");
        }

        [Test]
        public async Task WhenGetTodoItem_GivenTheIdIsNotFound_ThenNullIsReturned()
        {
            // Arrange
            var todoService = new TodoService();
            var invalidId = 333;

            // Act
            todoService.Add(new DataModel.TodoItem { Id = 1, Description = "New" });
            var result = await todoService.GetTodoItemAsync(invalidId);

            // Assert
            Assert.IsNull(result, "Null must be returned");
        }

        [Test]
        public async Task WhenGetTodoItem_GivenTheIdIsValid_ThenTheItemIsReturned()
        {
            // Arrange
            var todoService = new TodoService();
            var validId = 1;

            // Act
            todoService.Add(new DataModel.TodoItem { Id = 1, Description = "New" });
            var result = await todoService.GetTodoItemAsync(validId);

            // Assert
            Assert.IsNotNull(result, "Cannot return null");
            Assert.IsTrue(result.Id == validId, "Returned item must have the valid Id");
        }

        [Test]
        public void WhenChangeStatus_GivenTheIdIsNotFound_ThenFalseIsReturned()
        {
            // Arrange
            var todoService = new TodoService();
            var invalidId = 333;

            // Act
            todoService.Add(new DataModel.TodoItem { Id = 1, Description = "New" });
            var result = todoService.ChangeStatus(invalidId, true);

            // Assert
            Assert.IsFalse(result, "false must be returned");
        }

        [Test]
        public async Task WhenChangeStatus_GivenValidIdAndSameStatus_ThenTrueIsReturnedAndStatusUnchanged()
        {
            // Arrange
            var todoService = new TodoService();
            var validId = 1;
            var anItem = new DataModel.TodoItem { Id = 1, Description = "New", IsComplete = false };
            var originalStatus = anItem.IsComplete;

            // Act
            todoService.Add(anItem);
            var result = todoService.ChangeStatus(validId, originalStatus);
            var changedItem = await todoService.GetTodoItemAsync(validId);

            // Assert
            Assert.IsTrue(result, "true must be returned");
            Assert.IsTrue(changedItem.IsComplete == originalStatus, "New status must not change");
        }

        [Test]
        public async Task WhenChangeStatus_GivenValidIdAndDifferentStatus_ThenTrueIsReturnedAndStatusIsChanged()
        {
            // Arrange
            var todoService = new TodoService();
            var validId = 1;
            var anItem = new DataModel.TodoItem { Id = 1, Description = "New", IsComplete = false };
            var newStatus = !anItem.IsComplete;

            // Act
            todoService.Add(anItem);
            var result = todoService.ChangeStatus(validId, newStatus);
            var changedItem = await todoService.GetTodoItemAsync(validId);

            // Assert
            Assert.IsTrue(result, "true must be returned");
            Assert.IsTrue(changedItem.IsComplete == newStatus, "New status must be changed");
        }
    }
}
