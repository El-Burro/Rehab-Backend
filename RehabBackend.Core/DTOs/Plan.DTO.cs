public class PlanCreateDto
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public List<int> Patients { get; set; } = new();
    public List<int> Exercises { get; set; } = [];
}