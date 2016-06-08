using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace ServiceLocator
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class ServiceLocator : StatelessService
    {
        private Dictionary<string, string> _serviceCache;
        private FabricClient _fabricClient;

        public ServiceLocator(StatelessServiceContext context, FabricClient client)
            : base(context)
        {
            _serviceCache = new Dictionary<string, string>();
            _fabricClient = client;
        }

        private async Task preloadServiceCache()
        {
            throw new NotImplementedException();
        }

        public async Task<string> ResolveServiceEndpoint(string serviceName)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[0];
        }

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            long iterations = 0;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                ServiceEventSource.Current.ServiceMessage(this, "Working-{0}", ++iterations);

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
    }
}
