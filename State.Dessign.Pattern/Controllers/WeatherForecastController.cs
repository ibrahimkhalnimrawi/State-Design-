using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using State.Design.Pattern.Business.States;
using State.Design.Pattern.Domain;
using State.Design.Pattern.Dto;
using State.Design.Pattern.Infrastructure;

namespace State.Design.Pattern.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _context.Order.ToListAsync();
        return Ok(result);
    }


    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] OrderDto dto)
    {
        var order = new Order();
        order.Description = dto.Description;
        order.State = new DraftState();
        order.CreatedAt = DateTime.Now;
        await _context.Order.AddAsync(order);
        await _context.SaveChangesAsync();
        return Ok(order);
    }

    [HttpPut]
    [Route("{id}/confirm")]
    public async Task<IActionResult> Confirm(int id)
    {
        var order = await _context.Order.FindAsync(id);
        if (order is null)
            return BadRequest();

        order.State.Confirm(order);
        await _context.SaveChangesAsync();
        return Ok(order);
    }

    [HttpPut]
    [Route("{id}/cancel")]
    public async Task<IActionResult> Cancel(int id)
    {
        var order = await _context.Order.FindAsync(id);
        if (order is null)
            return BadRequest();

        order.State.Cancel(order);
        await _context.SaveChangesAsync();
        return Ok(order);
    }


    [HttpPut]
    [Route("{id}/process")]
    public async Task<IActionResult> Process(int id)
    {
        var order = await _context.Order.FindAsync(id);
        if (order is null)
            return BadRequest();

        order.State.Process(order);
        await _context.SaveChangesAsync();
        return Ok(order);
    }

}