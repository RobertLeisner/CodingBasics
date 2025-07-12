// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;

namespace CodingBasics.DependencyHandling.C05_DiContainer;

/// <summary>
/// Brand A Model X car
/// </summary>
public class CarBrandAModelY : CarBrandA
{
    /// <summary>
    /// Static factory method for <see cref="CarBrandAModelY"/>
    /// </summary>
    /// <param name="engine"></param>
    /// <returns></returns>
    public static CarBrandAModelY CreateInstance(IEngine engine)
    {
        return new CarBrandAModelY(engine);
    }


    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="engine">Injected dependency</param>
    public CarBrandAModelY(IEngine engine) : base(engine)
    {
        TypeName = "Model Y";
    }

    /// <summary>
    /// Start the engine of the car the way model Y needs it
    /// </summary>
    public override void StartEngine()
    {
        // Start engine here
        Debug.Print($"Engine of car model {ManufacturerName} {TypeName} starts...");
        // Writes: Engine of car model BrandACompany Model Y starts...

        FireEngineStartedEvent();
    }

}