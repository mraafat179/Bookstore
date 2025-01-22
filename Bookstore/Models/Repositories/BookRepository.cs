namespace Bookstore.Models.Repositories
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book(){Id=5,Title="C# programmig",Description="No Data" ,Author=new Author(){Id=5} },
                new Book(){Id=10,Title="Java programmig",Description="Nothing",Author=new Author(){Id=10 } },
                new Book(){Id=15,Title="Python programmig",Description="No Description",Author=new Author(){Id=15 } }
            };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(book => book.Id) + 1;
            books.Add(entity);
        }
        public Book find(int id)
        {
            var book = books.SingleOrDefault(x => x.Id == id);
            return book;
        }
        public void Delete(int id)
        {
            var book = find(id);
            books.Remove(book);
        }

        

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id,Book newBook)
        {
            var book = find(id);  
            book.Title = newBook.Title;
            book.Description = newBook.Description; 
            book.Author = newBook.Author;
            
             
        }
    }
}
