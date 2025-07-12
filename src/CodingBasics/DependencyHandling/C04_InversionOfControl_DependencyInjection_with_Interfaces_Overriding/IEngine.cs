// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.DependencyHandling.C04_InversionOfControl_DependencyInjection_with_Interfaces_Overriding;

/// <summary>
/// Interface for cr engine implementations
/// </summary>
public interface IEngine
{
    /// <summary>
    /// Start the engine of the car
    /// </summary>
    void StartEngine();
}