// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Diagnostics;
using CodingBasics.DependencyHandling.C05_DiContainer;
using CodingBasics.Tests.Helpers;

namespace CodingBasics.Tests.DependencyHandling;

[TestFixture]
public class C05DiContainerTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    private bool _wasEventFired;

    /// <summary>
    /// Configure the DI container
    /// </summary>
    /// <returns>Configured DI container</returns>
    public DiContainer ContainerSetup()
    {
        var diContainer = new DiContainer();

        diContainer.AddSingleton<IEngineFactory, EngineFactory>();
        diContainer.AddSingleton<ICarFactory, CarFactory>();

        diContainer.BuildServiceProvider();

        return diContainer;
    }

    [Test]
    public void CarBrandAModelX_StartEngine_EventEngineStartedFired()
    {
        // Arrange 
        var diContainer = ContainerSetup();
        _wasEventFired = false;

        // Create the instance of the target class now with injected dependency
        var factory = diContainer.Get<ICarFactory>();

        var car = factory.CreateInstance(typeof(CarBrandAModelX));

        // Register the even CarOnEngineStartedEvent
        car.EngineStartedEvent += CarOnEngineStartedEvent;

        // Act
        car.StartEngine();

        // Assert
        Wait.Until(() => _wasEventFired);

        Assert.That(_wasEventFired, Is.True);
    }


    [Test]
    public void CarBrandAModelY_StartEngine_EventEngineStartedFired()
    {
        // Arrange 
        var diContainer = ContainerSetup();
        _wasEventFired = false;

        // Create the depencies now
        var engine = new Engine();

        // Create the instance of the target class now with injected dependency
        var factory = diContainer.Get<ICarFactory>();

        var car = factory.CreateInstance(typeof(CarBrandAModelY));

        // Register the even CarOnEngineStartedEvent
        car.EngineStartedEvent += CarOnEngineStartedEvent;

        // Act
        car.StartEngine();

        // Assert
        Wait.Until(() => _wasEventFired);

        Assert.That(_wasEventFired, Is.True);
    }

    private void CarOnEngineStartedEvent(object sender, EngineStartedEventHandlerArgs args)
    {
        Debug.Print(args.Message);
        _wasEventFired = true;
    }
}