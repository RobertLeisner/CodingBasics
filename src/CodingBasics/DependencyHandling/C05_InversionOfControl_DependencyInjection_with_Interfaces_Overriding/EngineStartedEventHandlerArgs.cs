namespace CodingBasics.DependencyHandling.C05_InversionOfControl_DependencyInjection_with_Interfaces_Overriding;

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