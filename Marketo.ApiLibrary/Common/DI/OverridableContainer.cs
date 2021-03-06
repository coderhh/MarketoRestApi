﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketo.ApiLibrary.Common.DI
{
    public class OverridableContainer : IMarketoApiContainer
    {
        private readonly AutofacContainer _container;

        public OverridableContainer(AutofacContainer container)
        {
            _container = container;
        }

        public bool IsInitialized { get { return false; } }

#pragma warning disable 67
        public event EventHandler<MarketoApiContainerEventArgs> BeforeRegistrationCompletes;
#pragma warning restore 67

        public void Initialize()
        {
            throw new InvalidOperationException();
        }

        public void RegisterType<T, U>(RegistrationLifetime registrationLifetime = RegistrationLifetime.InstancePerResolve) where U : T
        {
            _container.RegisterType<T, U>(registrationLifetime);

            //JsonPropertyConverterRepository.TryOverride<T, U>();
            //JsonPropertiesConverterRepository.TryOverride<T, U>();
        }

        public void RegisterGeneric(Type sourceType, Type targetType, RegistrationLifetime registrationLifetime = RegistrationLifetime.InstancePerResolve)
        {
            _container.RegisterGeneric(sourceType, targetType, registrationLifetime);
        }

        public void RegisterInstance(Type T, object value)
        {
            _container.RegisterInstance(T, value);
        }

        public void RegisterType<T>(RegistrationLifetime registrationLifetime = RegistrationLifetime.InstancePerResolve)
        {
            _container.RegisterType<T>(registrationLifetime);
        }

        public T Resolve<T>(params IConstructorNamedParameter[] parameters)
        {
            return _container.Resolve<T>(parameters);
        }
    }
}
