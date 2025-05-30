// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.DependencyHandling.C02_InversionOfControl_DependencyInjection
{

    /// <summary>
    /// Class represents a car
    /// </summary>
    public class Car
    {

        private readonly Engine _engine;

        /// <summary>
        /// Default cor
        /// </summary>
        /// <param name="engine"></param>
        public Car(Engine engine)
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
