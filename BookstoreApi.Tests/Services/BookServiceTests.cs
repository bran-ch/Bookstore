using AutoFixture;
using AutoMapper;
using BookstoreApi.Entities;
using BookstoreApi.Mappings;
using BookstoreApi.Models;
using BookstoreApi.Repositories;
using BookstoreApi.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace BookstoreApi.Tests
{
    [TestFixture]
    public class BookServiceTests
    {
        private Fixture _fixture = new Fixture();

        private Mock<IBookstoreContext> _mockBookContext;

        private IMapper _mapper;

        private Mock<ILogger<BookService>> _mockLogger;

        private IBookService _sut;

        [OneTimeSetUp]
        public void SetUpClass()
        {
            _mockBookContext = new Mock<IBookstoreContext>();
            _mapper = MappingProfileConfiguration.InitializeAutoMapper().CreateMapper();
            _mockLogger = new Mock<ILogger<BookService>>();
        }

        [SetUp]
        public void SetUp()
        {
            _mockBookContext.Reset();
        }

        [Test]
        public void GetBookTest()
        {
            // Arrange
            var bookId = _fixture.Create<int>();
            var bookTitle = _fixture.Create<string>();
            var bookEntity = new BookEntity { BookId = bookId, Title = bookTitle };

            _mockBookContext.Setup(m => m.FindBook(bookId)).Returns(bookEntity);

            _sut = new BookService(_mockBookContext.Object, _mockLogger.Object);

            // Act
            var book = _sut.GetBook(bookId);

            // Assert
            Assert.IsNotNull(book);
            Assert.AreEqual(book.Title, bookTitle);
        }
    }
}
