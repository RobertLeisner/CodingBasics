namespace CodingBasics.DependencyHandling.C01_TightCoupled;

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