using APBD8_pracadomowaa.Data;

namespace APBD8_pracadomowaa.Services;

public interface IClientServices
{
    Task DeleteClient(int clientId, Apbd8Context context);
}