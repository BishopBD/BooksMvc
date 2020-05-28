using BooksMvc.Domain;
using BooksMvc.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksDataContext _dataContext;

        public BooksController(BooksDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            //var response = 
            //    await 
            //        _dataContext
            //            .Books
            //            .Where(b => b.InInventory)
            //            .ToListAsync();

            //return View(response);

            var response = new GetBooksResponseModel
            {
                Books = await _dataContext.Books.Where(b => b.InInventory).Select(b => new BooksResponseItemModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author
                }).ToListAsync(),
                NumberOfBooksInInventory = await _dataContext.Books.CountAsync(b => b.InInventory),
                NumberOfBooksNotInInventory = await _dataContext.Books.CountAsync(b => b.InInventory == false)
            };

            return View(response);
        }
    }
}
