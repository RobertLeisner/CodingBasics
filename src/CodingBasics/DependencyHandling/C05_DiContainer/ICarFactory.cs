// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.DependencyHandling.C05_DiContainer;

/// <summary>
/// Interface for car factory
/// </summary>
public interface ICarFactory
{
    /// <summary>
    /// Create a
    /// </summary>
    /// <param name="typeOfCar">Type of the car to create</param>
    /// <returns>New car instance</returns>
    public ICar CreateInstance(Type typeOfCar);

}