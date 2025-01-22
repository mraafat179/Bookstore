using Microsoft.AspNetCore.Authorization;

namespace Bookstore.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {
        List<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author(){Id=5,FullName="Mohamed"},
                new Author(){Id=10,FullName="Omar"},
                new Author(){Id=15,FullName="Ahmed"},
                new Author(){Id=20,FullName="Khaled"}
            };
        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(author => author.Id)+1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = find(id);
            authors.Remove(author);
        }

        public Author find(int id)
        {
            var author = authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(int id, Author newAuthor)
        {
            var author = find(id);
            author.FullName= newAuthor.FullName;   

        }
    }
}
