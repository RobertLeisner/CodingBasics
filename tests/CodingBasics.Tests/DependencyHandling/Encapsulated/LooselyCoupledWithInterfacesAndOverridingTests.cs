// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Diagnostics;
using CodingBasics.DependencyHandling.C05_InversionOfControl_DependencyInjection_with_Interfaces_Overriding;
using CodingBasics.Tests.Helpers;

namespace CodingBasics.Tests.DependencyHandling.Encapsulated;

[TestFixture]
public class LooselyCoupledWithInterfacesAndOverridingTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    private bool _wasEventFired;

    [Test]
    public void CarBrandAModelX_StartEngine_EventEngineStartedFired()
    {
        // Arrange 
        _wasEventFired = false;

        // Create the depencies now
        var engine = new Engine();

        // Create the instance of the target class now with injected dependency
        var car = new CarBrandAModelX(engine);

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
        _wasEventFired = false;

        // Create the depencies now
        var engine = new Engine();

        // Create the instance of the target class now with injected dependency
        var car = new CarBrandAModelY(engine);

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