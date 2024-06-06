using APBD8_pracadomowaa.Data;
using APBD8_pracadomowaa.DTOs;
using APBD8_pracadomowaa.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD8_pracadomowaa.Controllers;


[Route("api/trips")]
[ApiController]
public class TripController : ControllerBase
{
    private readonly Apbd8Context _context;
    private readonly ITripServices _tripServices;

    public TripController(Apbd8Context context, ITripServices tripServices)
    {
        _context = context;
        _tripServices = tripServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips([FromQuery] int page)
    {
        var result = _tripServices.GetAllTrips(_context, page);

        if (result == null)
        {
            return NotFound("There are no trips");
        }
        
        return Ok(result);
    }

    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int idTrip, [FromBody] ClientToTripDTO clientToTripDto)
    {
        
        _tripServices.AssignClientToTrip(_context, idTrip, clientToTripDto);

        return Created();
    }
    
    
}