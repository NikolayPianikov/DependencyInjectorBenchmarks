using System;
using IoC;
using DependencyInjectorBenchmarks.Scenarios;
using IoC.Features;

namespace DependencyInjectorBenchmarks.Containers
{
    public sealed class IoCContainerBenchmark : IContainerBenchmark
    {
        public static readonly IoCContainerBenchmark Instance = new IoCContainerBenchmark();

        private readonly Container container;
        private readonly Resolver<ISingleton> resolveSingleton;
        private readonly Resolver<ITransient> resolveTransient;
        private readonly Resolver<ICombined> resolveCombined;
        private readonly object[] emptyArgs = Array.Empty<object>();

        public IoCContainerBenchmark()
        {
            this.container = Container.Create(CoreFeature.Set);
            this.container.Bind<ISingleton>().As(Lifetime.Singleton).To<Singleton>()
                .Bind<ITransient>().To<Transient>()
                .Bind<ICombined>().To<Combined>();
            this.resolveSingleton = this.container.GetResolver<ISingleton>();
            this.resolveTransient = this.container.GetResolver<ITransient>();
            this.resolveCombined = this.container.GetResolver<ICombined>();
        }

        public ISingleton ResolveSingleton() => this.resolveSingleton(container, this.emptyArgs);

        public ITransient ResolveTransient() => this.resolveTransient(container, this.emptyArgs);

        public ICombined ResolveCombined() => this.resolveCombined(container, this.emptyArgs);
    }
}
