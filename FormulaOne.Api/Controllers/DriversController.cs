using AutoMapper;
using FormulaOne.Api.Command;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController(IMediator mediator) :BaseController(mediator)
{
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var query=new GetDriverQuery(driverId);
        var result= await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDriver()
    {
        // Specifying the query that I have for this endpoint
        var query = new GetAllDriversQuery();
        var result=await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var Command = new CreateDriverInfoRequest(request);
        var result = await mediator.Send(Command);
        return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);

    }
    
    [HttpPut("")]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var command = new UpdateDriverInfoRequest(request);
        var result = await mediator.Send(command);
        return result ? NoContent():BadRequest();
    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var Command=new DeleteDriverInfoRequest(driverId);
        var result = await mediator.Send(Command);
        return result ? NoContent():BadRequest();
    }

}