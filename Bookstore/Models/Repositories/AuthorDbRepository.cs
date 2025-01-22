﻿namespace Bookstore.Models.Repositories
{
    public class AuthorDbRepository:IBookstoreRepository<Author>
    {
        BookstoreDbContext db;
        public AuthorDbRepository(BookstoreDbContext db)
        {
            this.db = db;
        }
        public void Add(Author entity)
        {
            db.Authors.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public Author find(int id)
        {
            var author = db.Authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public IList<Author> List()
        {
            return db.Authors.ToList();
        }

        public void Update(int id, Author newAuthor)
        {
            db.Update(newAuthor);
            db.SaveChanges();  

        }
    }
}
