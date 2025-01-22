using Microsoft.EntityFrameworkCore;

namespace Bookstore.Models.Repositories
{
    public class BookDbRepository : IBookstoreRepository<Book>
    {
        BookstoreDbContext db;
        public BookDbRepository(BookstoreDbContext db)
        {
           this.db = db;
        }
        public void Add(Book entity)
        {
            
            db.Books.Add(entity);
            db.SaveChanges();
        }
        public Book find(int id)
        {
            var book = db.Books.Include(a => a.Author).SingleOrDefault(x => x.Id == id);
            return book;
        }
        public void Delete(int id)
        {
            var book = find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }



        public IList<Book> List()
        {
            return db.Books.Include(a=>a.Author).ToList();
        }

        public void Update(int id, Book newBook)
        {
            db.Books.Update(newBook);
            db.SaveChanges();

        }
    }
}
