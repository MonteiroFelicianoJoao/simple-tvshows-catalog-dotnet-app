namespace TvShowCatalog.Interfaces
{
    public interface IRepository<T>
    {
         List<T> List();
         T ReturnById(int id);
         void Insert(TvShow entity);
         void Delete(int id);
         void Update(int id, TvShow entity);
         int NextId();
    }
}