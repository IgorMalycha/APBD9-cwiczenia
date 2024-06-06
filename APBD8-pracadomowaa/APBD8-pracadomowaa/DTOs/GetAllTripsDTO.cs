using APBD8_pracadomowaa.Models;

namespace APBD8_pracadomowaa.DTOs;

public class GetAllTripsDTO
{
    public int PageNum { get; set; }
    public int PageSize { get; set; }
    public int AllPages { get; set; }
    public IEnumerable<TripDTO> trips { get; set; }
    
}