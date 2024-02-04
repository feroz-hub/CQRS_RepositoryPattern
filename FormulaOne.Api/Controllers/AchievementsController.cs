using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class AchievementsController(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator) :BaseController(unitOfWork, mapper)
{
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var query = new GetDriverAchievementQuery(driverId);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var result = mapper.Map<Achievement>(request);
        await unitOfWork.Achievements.Add(result);
        await unitOfWork.CompletedAsync();
        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);

    }
    
    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var result = mapper.Map<Achievement>(request);
        await unitOfWork.Achievements.Update(result);
        await unitOfWork.CompletedAsync();
        return NoContent();

    }
}