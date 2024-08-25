namespace Multitenancy.Database.Tenant.Repositories.Interfaces;

public interface IDataRepository
{
    Task<IEnumerable<Data>> GetData();
    Task AddData(Data data);
}