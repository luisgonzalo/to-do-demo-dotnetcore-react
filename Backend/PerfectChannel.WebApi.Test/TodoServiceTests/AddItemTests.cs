using NUnit.Framework;
using PerfectChannel.DataModel;
using PerfectChannel.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectChannel.WebApi.Test.TodoServiceTests
{
    [TestFixture]
    public class AddItemTests
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
        public void WhenATodoItemIsAdded_GivenItemIsNull_ThenReturnFalse()
        {
            // Arrange
            
            // Act
            var result = _todoService.Add(null);

            // Assert
            Assert.IsFalse(result, "Add must return false");
        }

        [Test]
        public void WhenATodoItemIsAdded_GivenDescriptionIsNull_ThenReturnFalse()
        {
            // Arrange
            var item = new TodoItem { IsComplete = false };

            // Act
            var result = _todoService.Add(item);

            // Assert
            Assert.IsFalse(result, "Add must return false");
        }

        [Test]
        public void WhenATodoItemIsAdded_GivenDescriptionIsEmpty_ThenReturnFalse()
        {
            // Arrange
            var item = new TodoItem { IsComplete = false, Description = "" };

            // Act
            var result = _todoService.Add(item);

            // Assert
            Assert.IsFalse(result, "Add must return false");
        }

        [Test]
        public void WhenATodoItemIsAdded_GivenDescriptionIsWhitespaces_ThenReturnFalse()
        {
            // Arrange
            var item = new TodoItem { IsComplete = false, Description = "  " };

            // Act
            var result = _todoService.Add(item);

            // Assert
            Assert.IsFalse(result, "Add must return false");
        }

        [Test]
        public void WhenATodoItemIsAdded_GivenValidItem_ThenReturnTrueAndItemIdIsOne()
        {
            // Arrange
            var item = new TodoItem { IsComplete = false, Description = "first item", Id = 123 };

            // Act
            var result = _todoService.Add(item);

            // Assert
            Assert.IsTrue(result, "Must return true");
            Assert.IsTrue(item.Id == 1, "New item Id must be 1");
        }

        [Test]
        public void WhenSeveralTodoItemsAreAdded_GivenValidItems_ThenIdsAreSequential()
        {
            // Arrange
            var first = new TodoItem { IsComplete = false, Description = "first item", Id = 123 };
            var second = new TodoItem { IsComplete = false, Description = "second item", Id = 123 };
            var third = new TodoItem { IsComplete = false, Description = "third item", Id = 123 };

            // Act
            var firstResult = _todoService.Add(first);
            var secondResult = _todoService.Add(second);
            var thirdResult = _todoService.Add(third);

            // Assert
            Assert.IsTrue(firstResult && secondResult && thirdResult, "All must return true");
            Assert.IsTrue(first.Id == 1 && second.Id == 2 && third.Id == 3, "New item Ids must be sequential");
        }
    }
}
