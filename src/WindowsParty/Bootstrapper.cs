﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;
using WindowsParty.Helpers;
using WindowsParty.Interfaces;
using WindowsParty.ViewModels;

namespace WindowsParty
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _simpleContainer;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _simpleContainer = new SimpleContainer();

            _simpleContainer.Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAuthenticationHelper, AuthenticationHelper>()
                .Singleton<IWebTasks, WebTasks>();


            _simpleContainer.PerRequest<ShellViewModel>()
                .PerRequest<LoginViewModel>()
                .PerRequest<ServerListViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _simpleContainer.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _simpleContainer.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _simpleContainer.BuildUp(instance);
        }
    }
}
