// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Diagnostics;
using CodingBasics.DependencyHandling.C01_TightCoupled;
using CodingBasics.Tests.Helpers;

namespace CodingBasics.Tests.DependencyHandling.Encapsulated;

public class TightCoupledTests
{

    private bool _wasEventFired;

    [Test]
    public void Car_StartEngine_EventEngineStartedFired()
    {
        // Arrange 
        _wasEventFired = false;

        var car = new Car
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