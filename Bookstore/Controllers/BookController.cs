using Bookstore.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;
using Bookstore.ViewModels;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        private readonly IBookstoreRepository<Book> bookRepo;
        private readonly IBookstoreRepository<Author> authorRepo;

        public BookController(IBookstoreRepository<Book> bookRepo, IBookstoreRepository<Author> authorRepo)
        {
            this.bookRepo = bookRepo;
            this.authorRepo = authorRepo;
        }
        public ActionResult Index()
        {
            var book = bookRepo.List();
            return View(book);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepo.find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAuhtorViewModel
            {
                Authors = FillSelectList()
            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuhtorViewModel model)
        {
            
            try
            {

                if (model.AuthorId == -1)
                {
                    ViewBag.Message = "Please select an author from the list";
                    var vmodel = new BookAuhtorViewModel
                    {
                        Authors = FillSelectList()
                    };
                    return View(vmodel);
                }
                Book book = new Book()
                {
                    Id = model.BookId,
                    Title = model.Title,
                    Description = model.Description,
                    Author = authorRepo.find(model.AuthorId)

                };
                bookRepo.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
           
                
            
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepo.find(id);
            var authorId = book.Author == null ? book.Author.Id = 0 : book.Author.Id;
            var model = new BookAuhtorViewModel
            {
                BookId=book.Id,
                Title = book.Title,
                Description=book.Description,
                AuthorId = authorId,
                Authors = authorRepo.List().ToList()
            };
            return View(model);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuhtorViewModel viewModel)
        {
            try
            {
                var author = authorRepo.find(viewModel.AuthorId);
                Book book = new Book()
                {
                    Id=viewModel.BookId,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Author =author
                };
                bookRepo.Update(viewModel.BookId,book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = bookRepo.find(id);
            
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book model)
        {
            try
            {
                bookRepo.Delete(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        List<Author> FillSelectList()
        {
            var authors = authorRepo.List().ToList();
            authors.Insert(0, new Author { Id = -1, FullName = "-----Please select an author-------" });
            return authors;
        }

    }
}
