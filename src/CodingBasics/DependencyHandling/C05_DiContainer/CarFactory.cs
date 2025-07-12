// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.DependencyHandling.C05_DiContainer;

/// <summary>
/// Factory implementation
/// </summary>
public class CarFactory : ICarFactory
{
    private readonly IEngineFactory _engineFactory;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="engineFactory"></param>
    public CarFactory(IEngineFactory engineFactory)
    {
        _engineFactory = engineFactory;
    }


    /// <summary>
    /// Create a
    /// </summary>
    /// <param name="typeOfCar">Type of the car to create</param>
    /// <returns>New car instance</returns>
    public ICar CreateInstance(Type typeOfCar)
    {
        var engine = _engineFactory.CreateInstance();

        if (typeOfCar == typeof(CarBrandAModelX))
        {
            return CarBrandAModelX.CreateInstance(engine);
        }

        if (typeOfCar == typeof(CarBrandAModelY))
        {
            return CarBrandAModelY.CreateInstance(engine);
        }

        throw new ArgumentException("No valid car type");
    }
}