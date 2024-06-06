using APBD8_pracadomowaa.Data;
using APBD8_pracadomowaa.DTOs;

namespace APBD8_pracadomowaa.Repositories;

public interface ITripRepository
{
    Task<GetAllTripsDTO> getAllTrips(Apbd8Context context, int pageNum);
    Task AssignClientToTrip(Apbd8Context context, int idTrip, ClientToTripDTO clientToTripDto);
    Task<bool> ExistsClientWithGivenPesel(Apbd8Context context, ClientToTripDTO clientToTripDto);
    Task<bool> DoesTripOnThisPeselExists(Apbd8Context context, int idTrip);
    Task<bool> DoesTripExist(Apbd8Context context, int  idTrip);
    Task<bool> IsDateFromInPast(Apbd8Context context, ClientToTripDTO clientToTripDto);
    
    
}