using Microsoft.AspNetCore.Mvc;
using TestAPICustomerBusinessLogic;
using TestAPICustomerBusinessLogic.Repository;

namespace TestAPICustomer.Controller;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : BaseController
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IRepository<Customer> _customerRepository;
    public CustomerController(ILogger<CustomerController> logger, IRepository<Customer> customerRepository) : base(logger)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        return await HandleResponse(_customerRepository.GetAllAsync);
    }
    [HttpPost]
    public async Task<IActionResult> AddCustomer(Customer customer)
    {
        return await HandleResponse(async () => await _customerRepository.AddAsync(customer), "add data");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
    {
        return await HandleResponse(async () => await _customerRepository.UpdateAsync(customer));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        return await HandleResponse(async () => await _customerRepository.DeleteAsync(id));
    }
}