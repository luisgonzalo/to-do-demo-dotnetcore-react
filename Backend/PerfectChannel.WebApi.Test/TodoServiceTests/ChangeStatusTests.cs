using NUnit.Framework;
using PerfectChannel.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Test.TodoServiceTests
{
    [TestFixture]
    public class ChangeStatusTests
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
            _todoService.Dispose();
        }

        [Test]
        public void WhenChangeStatus_GivenTheIdIsNotFound_ThenFalseIsReturned()
        {
            // Arrange
            var invalidId = 333;

            // Act
            _todoService.Add(new DataModel.TodoItem { Id = 1, Description = "New" });
            var result = _todoService.ChangeStatus(invalidId, true);

            // Assert
            Assert.IsFalse(result, "false must be returned");
        }

        [Test]
        public async Task WhenChangeStatus_GivenValidIdAndSameStatus_ThenTrueIsReturnedAndStatusUnchanged()
        {
            // Arrange
            var validId = 1;
            var anItem = new DataModel.TodoItem { Id = 1, Description = "New", IsComplete = false };
            var originalStatus = anItem.IsComplete;

            // Act
            _todoService.Add(anItem);
            var result = _todoService.ChangeStatus(validId, originalStatus);
            var changedItem = await _todoService.GetTodoItemAsync(validId);

            // Assert
            Assert.IsTrue(result, "true must be returned");
            Assert.IsTrue(changedItem.IsComplete == originalStatus, "New status must not change");
        }

        [Test]
        public async Task WhenChangeStatus_GivenValidIdAndDifferentStatus_ThenTrueIsReturnedAndStatusIsChanged()
        {
            // Arrange
            var validId = 1;
            var anItem = new DataModel.TodoItem { Id = 1, Description = "New", IsComplete = false };
            var newStatus = !anItem.IsComplete;

            // Act
            _todoService.Add(anItem);
            var result = _todoService.ChangeStatus(validId, newStatus);
            var changedItem = await _todoService.GetTodoItemAsync(validId);

            // Assert
            Assert.IsTrue(result, "true must be returned");
            Assert.IsTrue(changedItem.IsComplete == newStatus, "New status must be changed");
        }
    }
}
