// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.Inheritance.C02_Inheritance_with_overriding
{
    /// <summary>
    /// Base class car
    /// </summary>
    public abstract class Car
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
        public virtual void StartEngine()
        {
            throw new NotSupportedException();
        }


    }
}
