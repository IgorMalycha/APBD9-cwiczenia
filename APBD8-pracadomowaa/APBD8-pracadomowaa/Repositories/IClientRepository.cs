using APBD8_pracadomowaa.Data;

namespace APBD8_pracadomowaa.Repositories;

public interface IClientRepository
{
    Task DeleteClientById(int clientId, Apbd8Context context);
    Task<bool> DoesHaveTrips(int clientId, Apbd8Context context);
    
}