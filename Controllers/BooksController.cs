using Microsoft.AspNetCore.Mvc;
using Chapter18.Models;
namespace Chapter18.Controllers {
    [Route("api/[controller]")]
    public class BooksController : ControllerBase {
        [HttpGet]
        public IEnumerable<Book> GetBooks() {
            return new Book[] {
                new Book() { Name = "Book #1" },
                new Book() { Name = "Book #2" },
            };
        }
        [HttpGet("{id}")]
        public Book GetBook() {
            return new Book() {
                BookId = 1, Name = "Test Book"
            };
        }
    }
    }
