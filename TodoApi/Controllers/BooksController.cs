using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.DAL;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.Where(b => b.IsDeleted == false).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookUpdateDTO updateDTO)
        {

            
            var dbBook = _context.Books.Find(id);
            if (dbBook == null) return NotFound();
            dbBook.BookName = updateDTO.BookName ?? dbBook.BookName;
            dbBook.Genre = updateDTO.Genre ?? dbBook.Genre;

            _context.Books.Update(dbBook);
            await _context.SaveChangesAsync();


            return Ok(dbBook);
        }

        [HttpPost]
        public async Task<ActionResult> PostBook(BookCreateDTO bookDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (bookDTO == null) return StatusCode(StatusCodes.Status400BadRequest, new { errorCode = 1087, message = "Model is invalid" });

            var book = new Book
            {
                BookName = bookDTO.BookName,
                Genre = bookDTO.Genre,
                IsDeleted = false
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            //_context.Books.Remove(book);

            book.IsDeleted = true;
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
