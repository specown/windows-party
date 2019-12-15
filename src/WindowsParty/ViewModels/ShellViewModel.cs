

using Caliburn.Micro;
using System;

namespace WindowsParty.ViewModels
{
    public class ShellViewModel : Screen
    {
        IEventAggregator _eventAggregator;
        LoginViewModel _loginViewModel;
        ServerListViewModel _serverListViewModel;

        public ShellViewModel(IEventAggregator eventAggregator, LoginViewModel loginViewModel, ServerListViewModel serverListViewModel)
        {
            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            _loginViewModel = loginViewModel ?? throw new ArgumentNullException(nameof(loginViewModel));
            _serverListViewModel = serverListViewModel ?? throw new ArgumentNullException(nameof(serverListViewModel));
        }
    }
}
