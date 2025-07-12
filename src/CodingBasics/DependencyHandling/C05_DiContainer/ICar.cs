// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace CodingBasics.DependencyHandling.C05_DiContainer;

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