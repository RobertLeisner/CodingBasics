// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.DependencyHandling.C03_InversionOfControl_DependencyInjection_with_Interfaces
{
    /// <summary>
    /// Class represents a car
    /// </summary>
    public class Car : ICar
    {

        private readonly IEngine _engine;

        /// <summary>
        /// Default cor
        /// </summary>
        /// <param name="engine"></param>
        public Car(IEngine engine)
        {
            // *****************************
            // Store the injected instance locally: loose coupling
            // *****************************
            _engine = engine;

        }


        /// <summary>
        /// Event fired when engine is started
        /// </summary>

        public event EngineStartedHandler EngineStartedEvent;

        /// <summary>
        /// Name of the car type
        /// </summary>

        public string TypeName { get; set; }

        /// <summary>
        /// Manufacturer name
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// Start the engine of the car
        /// </summary>
        public void StartEngine()
        {
            // Start engine here
            _engine.StartEngine();

            // Engine started: fire event
            var args = new EngineStartedEventHandlerArgs
            {
                Message = $"Engine of car model {ManufacturerName} {TypeName} started.."
            };

            EngineStartedEvent?.Invoke(this, args);

        }
    }
}
