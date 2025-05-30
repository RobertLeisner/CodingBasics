// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Diagnostics;

namespace CodingBasics.Inheritance.C01_Simple_Inheritance
{
    /// <summary>
    /// Base class car
    /// </summary>
    public class Car
    {
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
            Debug.Print($"Engine of car model {ManufacturerName} {TypeName} starts...");
        }


    }
}
