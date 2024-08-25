using Microsoft.EntityFrameworkCore;
using Multitenancy.Database.Tenant.Repositories.Interfaces;

namespace Multitenancy.Database.Tenant.Repositories.Implementations;

public class DataRepository : IDataRepository
{
    private readonly TenantDbContext _context;
    public DataRepository(TenantDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Data>> GetData()
    {
        return await _context.Data.ToArrayAsync(); 
    }

    public async Task AddData(Data data)
    {
        _context.Data.Add(data);
        await _context.SaveChangesAsync();
    }
}