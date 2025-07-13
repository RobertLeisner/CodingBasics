// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;

namespace CodingBasics.Inheritance.C02_Inheritance_with_overriding;

/// <summary>
/// Brand A Model X car
/// </summary>
public class CarBrandAModelY : CarBrandA
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CarBrandAModelY()
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
    }

}