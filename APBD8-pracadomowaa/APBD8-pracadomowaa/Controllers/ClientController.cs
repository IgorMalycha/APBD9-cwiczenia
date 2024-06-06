using APBD8_pracadomowaa.Data;
using APBD8_pracadomowaa.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD8_pracadomowaa.Controllers;


[Route("api")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly Apbd8Context _context;
    private readonly ITripServices _tripServices;
    private readonly IClientServices _clientServices;

    public ClientController(Apbd8Context context, ITripServices tripServices, IClientServices clientServices)
    {
        _context = context;
        _tripServices = tripServices;
        _clientServices = clientServices;
    }


    [HttpDelete("clients/{idClient}")]
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        await _clientServices.DeleteClient(idClient, _context);
        
        return Ok();
    }
    
    
}