using AutoMapper;
using FormulaOne.Api.Command;
using FormulaOne.DataService.Repositories.Interfaces;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class DelelteDriverInfoHandler(IUnitOfWork unitOfWork,IMapper mapper):IRequestHandler<DeleteDriverInfoRequest,bool>
{
    public async Task<bool> Handle(DeleteDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var driver = await unitOfWork.Drivers.GetById(request.DriverId);
        if (driver == null)
            return false;
       
        await unitOfWork.Drivers.Delete(request.DriverId);
        await unitOfWork.CompletedAsync();
        return true;
    }
}