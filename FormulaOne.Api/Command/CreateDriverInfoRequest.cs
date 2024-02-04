using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Command;

public class CreateDriverInfoRequest(CreateDriverRequest driverRequest):IRequest<GetDriverResponse>
{
    public CreateDriverRequest DriverRequest { get;  }=driverRequest;
    
}