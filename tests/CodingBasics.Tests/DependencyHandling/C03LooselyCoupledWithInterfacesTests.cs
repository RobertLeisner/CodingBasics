// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Diagnostics;
using CodingBasics.DependencyHandling.C02_InversionOfControl_DependencyInjection;
using CodingBasics.Tests.Helpers;

namespace CodingBasics.Tests.DependencyHandling;

[TestFixture]
public class C03LooselyCoupledWithInterfacesTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    private bool _wasEventFired;

    [Test]
    public void Car_StartEngine_EventEngineStartedFired()
    {
        // Arrange 
        _wasEventFired = false;

        // Create the depencies now
        var engine = new Engine();

        // Create the instance of the target class now with injected dependency
        var car = new Car(engine)
        {
            ManufacturerName = "BrandXY",
            TypeName = "Model XY"
        };

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