// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace CodingBasics.DependencyHandling.C05_DiContainer;

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