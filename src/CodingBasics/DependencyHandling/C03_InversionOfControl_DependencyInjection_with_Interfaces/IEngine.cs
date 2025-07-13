// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace CodingBasics.DependencyHandling.C03_InversionOfControl_DependencyInjection_with_Interfaces;

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