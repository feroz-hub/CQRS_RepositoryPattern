using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class GetAllDriversHandler(IUnitOfWork unitOfWork,IMapper mapper):IRequestHandler<GetAllDriversQuery,IEnumerable<GetDriverResponse>>
{
    public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
    {
        var drivers = await unitOfWork.Drivers.All();
        return mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
    }
}