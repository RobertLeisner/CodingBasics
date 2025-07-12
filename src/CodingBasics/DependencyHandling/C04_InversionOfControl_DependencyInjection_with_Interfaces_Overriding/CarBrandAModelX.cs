// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Diagnostics;

namespace CodingBasics.DependencyHandling.C04_InversionOfControl_DependencyInjection_with_Interfaces_Overriding;

/// <summary>
/// Brand A Model X car
/// </summary>
public class CarBrandAModelX : CarBrandA
{

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="engine">Injected dependency</param>
    public CarBrandAModelX(IEngine engine): base(engine)
    {
        TypeName = "Model X";
    }

    /// <summary>
    /// Start the engine of the car the way model X needs it
    /// </summary>
    public override void StartEngine()
    {
        // Start engine here
        Debug.Print($"Engine of car model {ManufacturerName} {TypeName} starts...");
        // Writes: Engine of car model BrandACompany Model X starts...

        FireEngineStartedEvent();
    }

}