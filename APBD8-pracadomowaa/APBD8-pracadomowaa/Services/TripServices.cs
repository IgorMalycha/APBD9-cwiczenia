using APBD8_pracadomowaa.Data;
using APBD8_pracadomowaa.DTOs;
using APBD8_pracadomowaa.Repositories;

namespace APBD8_pracadomowaa.Services;

public class TripServices : ITripServices
{
    private ITripRepository _tripRepository;

    public TripServices(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public Task<GetAllTripsDTO> GetAllTrips(Apbd8Context context, int pageNum)
    {
        Task<GetAllTripsDTO> getAllTripsDto = _tripRepository.getAllTrips(context, pageNum);

        return getAllTripsDto;
    }

    public async Task AssignClientToTrip(Apbd8Context context, int idTrip, ClientToTripDTO clientToTripDto)
    {
        if (await _tripRepository.ExistsClientWithGivenPesel(context, clientToTripDto))
        {
            throw new Exception($"Client with Pesel: {clientToTripDto.Pesel} exists");
        }

        if (await _tripRepository.DoesTripOnThisPeselExists(context, idTrip))
        {
            throw new Exception($"Client with Pesel: {clientToTripDto.Pesel} has been sighn to trip with id{idTrip}");
        }

        if (await _tripRepository.DoesTripExist(context, idTrip))
        {
            throw new Exception($"Trip with id: {idTrip} does not exist");
        }

        if (await _tripRepository.IsDateFromInPast(context, clientToTripDto))
        {
            throw new Exception($"Start of trip with id {idTrip} is in the past");
        }
        
        await _tripRepository.AssignClientToTrip(context, idTrip, clientToTripDto);
    }

    
}