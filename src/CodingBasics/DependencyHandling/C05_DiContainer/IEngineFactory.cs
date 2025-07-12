// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.DependencyHandling.C05_DiContainer;

/// <summary>
/// Interface for engine factories
/// </summary>
public interface IEngineFactory
{
    /// <summary>
    /// Create an engine instance
    /// </summary>
    /// <returns></returns>
    IEngine CreateInstance();

}