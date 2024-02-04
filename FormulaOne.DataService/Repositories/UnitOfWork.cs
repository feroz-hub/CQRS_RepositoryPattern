using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class UnitOfWork:IUnitOfWork,IDisposable
{
    private readonly AppDbContext _dbContext;
    public IDriverRepository Drivers { get; }
    public IAchievementRepository Achievements { get; }

    public UnitOfWork(AppDbContext dbContext,ILoggerFactory loggerFactory)
    {
        
        _dbContext =dbContext;
        var logger = loggerFactory.CreateLogger("logs");
        Achievements = new AchievementRepository(_dbContext, logger);
        
        Drivers=new DriverRepository(_dbContext,logger);
    }
    public async Task<bool> CompletedAsync()
    {
       var result= await _dbContext.SaveChangesAsync();
       return result > 0;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}