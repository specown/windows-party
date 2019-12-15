using Caliburn.Micro;
using System;

namespace WindowsParty.ViewModels
{
    public class LoginViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private string _username;
        private string _password;

        public LoginViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
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

        
    }
}
