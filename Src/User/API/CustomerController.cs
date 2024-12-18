using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KmpShopBackend.Src.Customer.Application.Ports.Inbound;
using KmpShopBackend.Src.User.Application.Dto;
using KmpShopBackend.Src.User.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace KmpShopBackend.Src.User.API
{
[ApiController]
[Route("api/v1/customers")] // Namespace and route consistency
public class UserController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<UserController> _logger;

    public UserController(ICustomerService customerService, ILogger<UserController> logger)
    {
        _customerService = customerService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAll();
        if (!customers.Any())
        {
            return NoContent();
        }
        return Ok(customers);
    }

    // ... other methods with similar improvements ...

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> RegisterCustomer([FromBody] CreatedCustomerRequest request)
    {
        try
        {
            var customer = await _customerService.Insert(request);
            if (customer == null)
            {
                return BadRequest("Failed to create customer. Please check the request data.");
            }
            return CreatedAtRoute(nameof(_customerService.GetById), new { id = customer.Id }, customer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error registering customer: {message}", ex.Message);
            return StatusCode(500, "Internal Server Error");
        }
    }
}
}