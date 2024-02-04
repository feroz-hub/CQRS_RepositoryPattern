using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class GetDriverAchievementHandler(IUnitOfWork unitOfWork,IMapper mapper):IRequestHandler<GetDriverAchievementQuery,DriverAchievementResponse>
{
    public async Task<DriverAchievementResponse> Handle(GetDriverAchievementQuery request, CancellationToken cancellationToken)
    {
        var driverAchievements = await unitOfWork.Achievements.GetDriverAchievementsAsync(request.DriverId);
        return driverAchievements == null?null: mapper.Map<DriverAchievementResponse>(driverAchievements);
    }
}