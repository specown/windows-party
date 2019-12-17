using System;
using System.Threading.Tasks;
using WindowsParty.Interfaces;
using WindowsParty.Models;

namespace WindowsParty.Helpers
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private IWebTasks _webTasks;

        public AuthenticationHelper(IWebTasks webTasks)
        {
            _webTasks = webTasks ?? throw new ArgumentNullException(nameof(webTasks));
        }

        public async Task AuthenticateUser(UserModel userModel)
        {
            try
            {
                AuthModel authResponse = await _webTasks.AuthenticateUser(userModel);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
