// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace CodingBasics.Inheritance.C02_Inheritance_with_overriding;

/// <summary>
/// Base class car brand A
/// </summary>
public abstract class CarBrandA : Car
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public CarBrandA()
    {
        ManufacturerName = "BrandACompany";
    }


}