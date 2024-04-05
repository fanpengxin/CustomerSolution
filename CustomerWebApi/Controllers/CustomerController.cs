using CustomerWebApi.Models;
using CustomerWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ICustomerRepository customerRepository, ILogger<CustomerController> logger)
    {
        _customerRepository = customerRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        try
        {
            var result = await _customerRepository.GetCustomersAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{customerId:int}")]
    public async Task<IActionResult> GetById(int customerId)
    {
        try
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            return Ok(customer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]Customer customer)
    {
        try
        {
            await _customerRepository.CreateAsync(customer);
            return Ok(customer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody]Customer customer)
    {
        try
        {
            await _customerRepository.UpdateAsync(customer);
            return Ok(customer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{customerId:int}")]
    public async Task<IActionResult> Delete(int customerId)
    {
        try
        {
            var customer = await _customerRepository.DeleteAsync(customerId);
            return Ok(customer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
