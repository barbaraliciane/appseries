namespace ProjectSeries.Interfaces
{
    public interface IRepository<T>
    {
         List<T> List();
         T ReturnId(int id);
         void Insert (T entity);
         void Exclude (int id);
         void Update(int id, T entity);
         int NextId();
    }
}