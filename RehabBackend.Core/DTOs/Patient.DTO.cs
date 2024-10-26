public class PatientCreateDto
{
    public string Name { get; set; } = String.Empty;
    public int ClientId { get; set; }
    public List<int> Plans { get; set; } = [];
}

public class PatientDto
{
    public int PatientId { get; set; }
    public string? Name { get; set; } = String.Empty;
}