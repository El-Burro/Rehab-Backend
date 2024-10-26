public class ExerciseCreateDto
{
    public string Name { get; set; } = String.Empty;
    public string Details { get; set; } = String.Empty;
    public List<int> Plans { get; set; } = new();
}