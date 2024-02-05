using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BaseController(IMediator mediator) : ControllerBase
{
    
   
}