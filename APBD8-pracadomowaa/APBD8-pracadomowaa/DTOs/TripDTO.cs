namespace APBD8_pracadomowaa.DTOs;

public class TripDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public IEnumerable<CountrieDTO> Countries { get; set; }
    public IEnumerable<ClientDTO> Clients { get; set; }
    
}