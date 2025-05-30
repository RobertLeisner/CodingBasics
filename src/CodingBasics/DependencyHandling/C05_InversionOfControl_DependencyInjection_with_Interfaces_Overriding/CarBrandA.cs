namespace CodingBasics.DependencyHandling.C05_InversionOfControl_DependencyInjection_with_Interfaces_Overriding;

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