using TvShowCatalog.Interfaces;

namespace TvShowCatalog.Classes
{
    public class TvShowRepository : IRepository<TvShow>
    {
        private List<TvShow> tvShowsList = new List<TvShow>();

        public void Insert(TvShow @object)
        {
            tvShowsList.Add(@object);
            //TODO call log register
        }

        public void Delete(int id)
        {
            tvShowsList[id].RemoveFormCatalog();
            //TODO call log register
        }

        public List<TvShow> List()
        {
            return tvShowsList;
        }

        public int NextId()
        {
            return tvShowsList.Count;
        }

        public void Update(int id, TvShow @object)
        {
            tvShowsList[id] = @object;
        }

        public TvShow ReturnById(int id)
        {
            return tvShowsList[id];
        }
    }
}