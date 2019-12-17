using System.Threading.Tasks;
using WindowsParty.Models;

namespace WindowsParty.Interfaces
{
    public interface IAuthenticationHelper
    {
        Task AuthenticateUser(UserModel userModel);
    }
}
