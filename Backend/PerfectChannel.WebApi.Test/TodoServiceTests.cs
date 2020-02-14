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
        public async Task WhenTodoListCreated_GivenNothingAdded_ThenResultIsAnEmptyListAsync()
        {
            // Arrange
            var todoService = new TodoService();

            // Act
            var todoList = await todoService.GetAllTodoItemsAsync();

            // Assert
            Assert.IsNotNull(todoList, "A new todo list cannot be null");
            Assert.IsTrue(todoList.Length == 0, "A new todo list must be empty");
        }
    }
}
