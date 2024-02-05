using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Command;

public class UpdateDriverInfoRequest(UpdateDriverRequest updateDriverRequest):IRequest<bool>
{
    public UpdateDriverRequest UpdateDriverRequest { get; } = updateDriverRequest;
}