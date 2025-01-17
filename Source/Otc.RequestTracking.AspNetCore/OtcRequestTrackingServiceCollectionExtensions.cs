using System;
using Otc.RequestTracking.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OtcRequestTrackingServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestTracking(this IServiceCollection services, Action<RequestTrackerConfigurationLambda> config)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            services.AddScoped<RequestTracker>();

            var configuration = new RequestTrackerConfigurationLambda(services);
            config.Invoke(configuration);

            return services;
        }
    }
}
