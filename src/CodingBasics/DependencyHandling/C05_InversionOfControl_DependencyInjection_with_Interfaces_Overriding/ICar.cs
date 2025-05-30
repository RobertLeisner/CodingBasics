namespace CodingBasics.DependencyHandling.C05_InversionOfControl_DependencyInjection_with_Interfaces_Overriding;

/// <summary>
/// Interface for car implementations
/// </summary>
public interface ICar
{
    /// <summary>
    /// Event fired when engine is started
    /// </summary>
    event EngineStartedHandler EngineStartedEvent;

    /// <summary>
    /// Name of the car type
    /// </summary>

    string TypeName { get; set; }

    /// <summary>
    /// Manufacturer name
    /// </summary>
    string ManufacturerName { get; set; }

    /// <summary>
    /// Start the engine of the car
    /// </summary>
    void StartEngine();
}