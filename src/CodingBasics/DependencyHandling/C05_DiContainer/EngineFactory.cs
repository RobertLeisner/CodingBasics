// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.DependencyHandling.C05_DiContainer;

/// <summary>
/// Current engine factory implementation
/// </summary>
public class EngineFactory : IEngineFactory
{
    /// <summary>
    /// Create an engine instance
    /// </summary>
    /// <returns></returns>
    public IEngine CreateInstance()
    {
        return new Engine();
    }
}