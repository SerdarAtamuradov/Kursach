using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using WebUI.Controllers;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book{BookID = 1, Name = "Book1"},
                new Book{BookID = 2, Name = "Book2"},
                new Book{BookID = 3, Name = "Book3"},
                new Book{BookID = 4, Name = "Book4"},
                new Book{BookID = 5, Name = "Book5"}
            });

            BooksController controller = new BooksController(mock.Object);
            controller.pageSize = 3;

            IEnumerable<Book> result = (IEnumerable<Book>)controller.List(2).Model;

            List<Book> books = result.ToList();
            Assert.IsTrue(books.Count == 2);
            Assert.AreEqual(books[0].Name, "Book4");
            Assert.AreEqual(books[1].Name, "Book5");

        }
    }
}
