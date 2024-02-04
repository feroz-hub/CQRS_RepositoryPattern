using AutoMapper;
using FormulaOne.Api.Command;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class GetDriverInfoHandler(IUnitOfWork unitOfWork,IMapper mapper):IRequestHandler<CreateDriverInfoRequest,GetDriverResponse>
{
    public async Task<GetDriverResponse> Handle(CreateDriverInfoRequest request, CancellationToken cancellationToken)
    {
      
        var driver = mapper.Map<Driver>(request.DriverRequest);
        await unitOfWork.Drivers.Add(driver);
        await unitOfWork.CompletedAsync();
        return mapper.Map<GetDriverResponse>(driver);
    }
}