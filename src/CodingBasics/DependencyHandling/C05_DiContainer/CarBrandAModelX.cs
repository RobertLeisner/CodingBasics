// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;

namespace CodingBasics.DependencyHandling.C05_DiContainer;

/// <summary>
/// Brand A Model X car
/// </summary>
public class CarBrandAModelX : CarBrandA
{

    /// <summary>
    /// Static factory method for <see cref="CarBrandAModelX"/>
    /// </summary>
    /// <param name="engine"></param>
    /// <returns></returns>
    public static CarBrandAModelX CreateInstance(IEngine engine)
    {
        return new CarBrandAModelX(engine);
    }

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