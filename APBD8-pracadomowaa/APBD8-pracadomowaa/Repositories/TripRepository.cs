using APBD8_pracadomowaa.Data;
using APBD8_pracadomowaa.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APBD8_pracadomowaa.Repositories;

public class TripRepository : ITripRepository
{
    public async Task<GetAllTripsDTO> getAllTrips(Apbd8Context context, int pageNum)
    {
        int pageSize = 10;
        var totalTrips = await context.Trips.CountAsync();
        var totalPages = (int)Math.Ceiling(totalTrips / (double)pageSize);


        var trips = await context.Trips.OrderByDescending(c => c.DateFrom)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize).Select(e => new TripDTO()
            {
                Name = e.Name,
                Description = e.Description,
                DateFrom = e.DateFrom,
                DateTo = e.DateTo,
                MaxPeople = e.MaxPeople,
                Countries = context.Countries.Select(c => new CountrieDTO()
                {
                    Name = c.Name
                }).ToList(),
                Clients = context.Clients.Select(c => new ClientDTO()
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName
                }).ToList()
            }).ToListAsync();


        GetAllTripsDTO getAllTripsDto = new GetAllTripsDTO()
        {
            PageNum = pageNum,
            PageSize = 10,
            AllPages = totalPages,
            trips = trips
        };

        return getAllTripsDto;
    }
    
    public async Task AssignClientToTrip(Apbd8Context context, int idTrip, ClientToTripDTO clientToTripDto)
    {
        
    }

    public async Task<bool> ExistsClientWithGivenPesel(Apbd8Context context, ClientToTripDTO clientToTripDto)
    {
        //return context.Clients.FirstOrDefaultAsync(c => c.Pesel == clientToTripDto.Pesel);
        return false;
    }

    public async Task<bool> DoesTripOnThisPeselExists(Apbd8Context context, int idTrip)
    {
        return false;
    }

    public async Task<bool> DoesTripExist(Apbd8Context context, int idTrip)
    {
        return false;
    }

    public async Task<bool> IsDateFromInPast(Apbd8Context context, ClientToTripDTO clientToTripDto)
    {
        return false;
    }

}