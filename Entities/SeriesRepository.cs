using ProjectSeries.Interfaces;

namespace ProjectSeries.Entities
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> listSeries = new List<Series>();
        public void Exclude(int id)
        {
            listSeries[id].Excludes();
        }

        public void Insert(Series entity)
        {
            listSeries.Add(entity);
        }

        public List<Series> List()
        {
            return listSeries;
        }

        public int NextId()
        {
            return listSeries.Count;
        }

        public Series ReturnId(int id)
        {
            return listSeries[id];
        }

        public void Update(int id, Series entity)
        {
            listSeries[id] = entity;
        }
    }
}