namespace Bookstore.Models.Repositories
{
    public interface IBookstoreRepository<TENTITY>
    {
        IList<TENTITY> List();
        TENTITY find(int id);
        void Add(TENTITY entity);
        void Update(int id,TENTITY entity);
        void Delete(int id);
    }
}
