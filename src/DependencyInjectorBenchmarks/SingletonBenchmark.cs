﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Order;
using DependencyInjectorBenchmarks.Containers;
using DependencyInjectorBenchmarks.Scenarios;

namespace DependencyInjectorBenchmarks
{
    [MemoryDiagnoser]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    [MarkdownExporter]
    public class SingletonBenchmark
    {
        [Benchmark(Baseline = true)]
        public ISingleton Direct() => DirectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton SimpleInjector() => SimpleInjectorBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Ninject() => NinjectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Autofac() => AutofacBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton AspNetCore() => AspNetCoreBenchmark.Instance.ResolveSingleton();
        
        [Benchmark]
        public ISingleton CastleWindsor() => CastleWindsorBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton LightInject() => LightInjectBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton StructureMap() => StructureMapBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton FsContainer() => FsContainerBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton DryIoc() => DryIocBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Unity() => UnityBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton MicroResolver() => MicroResolverBenchmark.Instance.ResolveSingleton();

        [Benchmark]
        public ISingleton Grace() => GraceBenchmark.Instance.ResolveSingleton();
    }
}
