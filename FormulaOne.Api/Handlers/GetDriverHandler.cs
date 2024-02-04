using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class GetDriverHandler(IUnitOfWork unitOfWork,IMapper mapper):IRequestHandler<GetDriverQuery,GetDriverResponse>
{
    public async Task<GetDriverResponse> Handle(GetDriverQuery request, CancellationToken cancellationToken)
    {
        var driver = await unitOfWork.Drivers.GetById(request.DriverId);
        return driver == null ? null : mapper.Map<GetDriverResponse>(driver);
    }
}