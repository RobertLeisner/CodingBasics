using System.Diagnostics;

namespace CodingBasics.Inheritance.C02_Inheritance_with_overriding;

/// <summary>
/// Brand A Model X car
/// </summary>
public class CarBrandAModelX : CarBrandA
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public CarBrandAModelX()
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
    }

}