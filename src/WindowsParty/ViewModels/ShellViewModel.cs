﻿using Caliburn.Micro;
using System;
using WindowsParty.Events;

namespace WindowsParty.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<EventModel>
    {
        IEventAggregator _eventAggregator;
        LoginViewModel _loginViewModel;
        ServerListViewModel _serverListViewModel;

        public ShellViewModel(IEventAggregator eventAggregator, LoginViewModel loginViewModel, ServerListViewModel serverListViewModel)
        {
            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            _loginViewModel = loginViewModel ?? throw new ArgumentNullException(nameof(loginViewModel));
            _serverListViewModel = serverListViewModel ?? throw new ArgumentNullException(nameof(serverListViewModel));

            _eventAggregator.Subscribe(this);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            ActivateItem(_loginViewModel);
        }

        public void Handle(EventModel eventMessage)
        {
            switch (eventMessage.Status)
            {
                case Status.Signin:
                    ActivateItem(_serverListViewModel);
                    break;

                case Status.Logout:
                    ActivateItem(_loginViewModel);
                    break;

                default:
                    break;
            }
        }
    }
}
