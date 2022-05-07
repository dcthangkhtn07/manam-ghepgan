using Manam.GhepGan.Model;

namespace Manam.GhepGan.Business.Interfaces
{
    public interface IIdentityBusiness
    {
        AccountModel? GetUserLogin(string username, string password);
    }
}
