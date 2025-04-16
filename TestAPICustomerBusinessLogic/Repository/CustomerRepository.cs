using Microsoft.EntityFrameworkCore;

namespace TestAPICustomerBusinessLogic.Repository;

public class CustomerRepository : IRepository<Customer>
{
    private readonly ApplicationDBContext _context;

    public CustomerRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.customer.ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.customer.FindAsync(id);
    }

    public async Task AddAsync(Customer entity)
    {
        await _context.customer.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer entity)
    {
        _context.customer.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var customer = await GetByIdAsync(id);
        if (customer != null)
        {
            _context.customer.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
