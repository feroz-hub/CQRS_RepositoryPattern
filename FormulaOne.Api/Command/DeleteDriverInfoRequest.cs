using MediatR;

namespace FormulaOne.Api.Command;

public class DeleteDriverInfoRequest(Guid driverId):IRequest<bool>
{
    public Guid DriverId { get; } = driverId;

}