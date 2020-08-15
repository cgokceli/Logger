using Logger.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Helpers {
    public class Container {
        private readonly ServiceProvider serviceProvider;
        public Container() {
            serviceProvider = new ServiceCollection()
                              .AddCustomLogging()
                              .BuildServiceProvider();
        }

        public T GetService<T>() {
            return this.serviceProvider.GetService<T>();
        }
    }
}
