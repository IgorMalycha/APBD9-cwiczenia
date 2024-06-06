using APBD8_pracadomowaa.Data;
using APBD8_pracadomowaa.DTOs;

namespace APBD8_pracadomowaa.Services;

public interface ITripServices
{
    Task<GetAllTripsDTO> GetAllTrips(Apbd8Context context, int pageNum);
    
    Task AssignClientToTrip(Apbd8Context context, int idTrip, ClientToTripDTO clientToTripDto);
}