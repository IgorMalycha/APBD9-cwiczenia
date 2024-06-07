using APBD8_pracadomowaa.Data;
using APBD8_pracadomowaa.DTOs;
using APBD8_pracadomowaa.Models;
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

        var idClient = await context.Clients.Where(c => c.Pesel == clientToTripDto.Pesel).Select(c => c.IdClient)
            .FirstOrDefaultAsync();
        context.Add(new ClientTrip()
        {
            IdTrip = clientToTripDto.IdTrip,
            IdClient = idClient,
            PaymentDate = clientToTripDto.PaymentDate,
            RegisteredAt = DateTime.Now
        });
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsClientWithGivenPesel(Apbd8Context context, ClientToTripDTO clientToTripDto)
    {
        return await context.Clients.AnyAsync(c => c.Pesel == clientToTripDto.Pesel);
    }

    public async Task<bool> DoesTripOnThisPeselExists(Apbd8Context context, int idTrip, ClientToTripDTO clientToTripDto)
    {
        return await context.ClientTrips.AnyAsync(c => c.IdClientNavigation.Pesel == clientToTripDto.Pesel && c.IdTrip == idTrip);
    }

    public async Task<bool> DoesTripExist(Apbd8Context context, int idTrip)
    {

        return await context.Trips.AnyAsync(e => e.IdTrip == idTrip);
    }

    public async Task<bool> IsDateFromInPast(Apbd8Context context, ClientToTripDTO clientToTripDto)
    {

        var date = await context.Trips.Where(e => e.IdTrip == clientToTripDto.IdTrip)
            .Select(e => e.DateFrom).FirstOrDefaultAsync();

        return date > DateTime.Now;
    }

}