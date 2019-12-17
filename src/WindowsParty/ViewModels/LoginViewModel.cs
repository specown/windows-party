using Caliburn.Micro;
using System;
using System.Threading.Tasks;
using WindowsParty.Events;
using WindowsParty.Interfaces;
using WindowsParty.Models;

namespace WindowsParty.ViewModels
{
    public class LoginViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private IAuthenticationHelper _authenticationHelper;
        private string _username;
        private string _password;

        public LoginViewModel(IEventAggregator eventAggregator, IAuthenticationHelper authenticationHelper)
        {
            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            _authenticationHelper = authenticationHelper ?? throw new ArgumentNullException(nameof(authenticationHelper));
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public async Task AuthUser()
        {
            try
            {
                UserModel userModel = new UserModel(Username, Password);
                await _authenticationHelper.AuthenticateUser(userModel);

                _eventAggregator.PublishOnUIThread(new EventModel(Status.Signin));
            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
