using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries;

public class GetDriverAchievementQuery(Guid driverId):IRequest<DriverAchievementResponse>
{
    public Guid DriverId { get; } = driverId;
}