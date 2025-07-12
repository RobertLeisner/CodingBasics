// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.DependencyHandling.C05_DiContainer
{
    /// <summary>
    /// Class represents a car
    /// </summary>
    public abstract class Car : ICar
    {
        protected readonly IEngine Engine;

        /// <summary>
        /// Default cor
        /// </summary>
        /// <param name="engine"></param>
        protected Car(IEngine engine)
        {
            // *****************************
            // Store the injected instance locally: loose coupling
            // *****************************
            Engine = engine;

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
        public virtual void StartEngine()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Fire the engine started event
        /// </summary>
        protected void FireEngineStartedEvent()
        {
            var args = new EngineStartedEventHandlerArgs
            {
                Message = $"Engine of car model {ManufacturerName} {TypeName} started.."
            };

            EngineStartedEvent?.Invoke(this, args);
        }
    }
}