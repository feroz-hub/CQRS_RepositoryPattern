namespace FormulaOne.Entities.DbSet;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime AddedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int Status { get; set; }
}