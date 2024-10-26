public class ClientCreateDto
{
    public string Name { get; set; } = String.Empty;
    public string Phone { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public List<int> Patients { get; set; } = new();
}

public class ClientWithPatientNamesDto
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public List<string> PatientNames { get; set; } = new();
}

public class ClientWithPatientsDto
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public List<PatientDto> Patients { get; set; } = new();
}