using System.ComponentModel.DataAnnotations.Schema;

namespace FormulaOne.Entities.DbSet;

public class Achievement:BaseEntity
{
    public int RaceWins { get; set; }
    public int PolePosition  { get; set; }
    public int FastestLap { get; set; }
    public int WorldChampionship { get; set; }
    
    public Guid DriverId { get; set; }
    //[ForeignKey("DriverId")]
    public virtual Driver? Driver { get; set; }
}