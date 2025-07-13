// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace CodingBasics.DependencyHandling.C04_InversionOfControl_DependencyInjection_with_Interfaces_Overriding;

/// <summary>
/// Base class car brand A
/// </summary>
public abstract class CarBrandA : Car
{

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="engine">Injected dependency</param>
    protected CarBrandA(IEngine engine): base(engine)
    {
        ManufacturerName = "BrandACompany";
    }
}