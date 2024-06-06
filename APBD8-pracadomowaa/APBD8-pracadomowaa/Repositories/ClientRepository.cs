using APBD8_pracadomowaa.Data;
using Microsoft.EntityFrameworkCore;

namespace APBD8_pracadomowaa.Repositories;

public class ClientRepository : IClientRepository
{
    public async Task DeleteClientById(int clientId, Apbd8Context context)
    {
        var client = await context.Clients.FirstOrDefaultAsync(e => e.IdClient == clientId);

        if (client == null)
        {
            throw new Exception("Nie ma takiego klienta w bazie");
        }

        context.Remove(client);
        
        //savechanges zapytać czy potrzebne
    }
    
    
    public async Task<bool> DoesHaveTrips(int clientId, Apbd8Context context)
    {
        return context.ClientTrips.Any(e => e.IdClient == clientId);
    }
    
}