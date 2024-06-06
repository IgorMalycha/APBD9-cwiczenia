using APBD8_pracadomowaa.Data;
using APBD8_pracadomowaa.Repositories;

namespace APBD8_pracadomowaa.Services;

public class ClientServices : IClientServices
{
    private IClientRepository _clientRepository;

    public ClientServices(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task DeleteClient(int clientId, Apbd8Context context)
    {

        if (await _clientRepository.DoesHaveTrips(clientId, context))
        {
            throw new Exception(
                $"Nie mozna usunac klienta o numerze{clientId}, ponieważ ma co najmniej jedna wycieczkę");
            
        }
        
        await _clientRepository.DeleteClientById(clientId, context);
        
    }
}