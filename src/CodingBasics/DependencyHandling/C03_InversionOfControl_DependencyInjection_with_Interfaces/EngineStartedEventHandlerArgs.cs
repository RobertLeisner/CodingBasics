// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace CodingBasics.DependencyHandling.C03_InversionOfControl_DependencyInjection_with_Interfaces;

/// <summary>
/// Args transported with the "engine started event". May be enhanced with additional properties
/// </summary>
public class EngineStartedEventHandlerArgs : EventArgs
{
    /// <summary>
    /// A message transported with the event args
    /// </summary>
    public string Message { get; set; }

}