﻿using System.ServiceModel.Description;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;

namespace Rhyous.Auth.TokenService.Behaviors
{
    public abstract class ServiceBehaviorBase : IServiceBehavior
    {
        public virtual void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public abstract void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase);

        public virtual void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}