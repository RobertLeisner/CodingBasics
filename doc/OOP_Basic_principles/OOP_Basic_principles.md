Object-oriented-programming (OOP) with C#
================

# Object-oriented-programming versus functional programming

## Functional programming

The first programming languages were functional languages. All code is organized in methods which can be controlled with input parameters. 
This coding style is limited as complexer development tasks lead to methods calls with endless parameter list. This makes the code less readable and difficult to test.

One weekness of functional programming is that keeping a data state is difficult to implement.

``` csharp
public int Calculate2Numbers(int number1, int number2)
{

	return number1+number2

}

public void DoSomething
{

	int number1 = 1;
	
	int number2 = 2;
	
	
	var result =Calculate2Numbers(number1, number2)
	

	Debug.Print(result);

}
```

Functional programming is very performant i.e. in mathematical context. Implement processes in business context is painful.

## Object-oriented-programming

OOP means a programming style where all code is organzied in objects with properties, methods and events. 

The basic idea of OOP is that one object reproduces one real object. The object car represents one car. 
The complexer a real object is the more subordinated objects as object may required.
This leads to hierachies of object types. Imagine a object car which may have subordinated objects like one engine and four tires.

If an objects is dependent of other objects we speak of dependecies the object requires.

Properties are used to the describe properties as color, state or name of an object.

Methods are giving activity to an object. A car object will have a StartEngine method i.e..

Events add the possiblity to react on certain situations a object is in. Imagine an event "EngineStarted" for a car object.


``` csharp
public void DoSomething()
{

	var car = new Car();
	
	car.Color = Colors.red;
	
	car.EngineStartEvent += OnEngineStarted;
	
	
	car.StartEngine();

}

public void OnEngineStarted(EventArgs args)
{
	// Do something if the car is started
}
```

# Basic principles of object-oriented programming

## S.O.L.I.D: the five basic principles of object-oriented programming and design

The SOLID concepts are:

-	The Single-responsibility principle: "There should never be more than one reason for a class to change.". In other words, every class should have only one responsibility.

-	The Open-closed principle: "Software entities ... should be open for extension, but closed for modification."

-	The Liskov substitution principle: "Functions that use pointers or references to base classes must be able to use objects of derived classes without knowing it". See also design by contract.

-	The Interface segregation principle: "Many client-specific interfaces are better than one general-purpose interface."

-	The Dependency inversion principle: "Depend upon abstractions, not concretions." 


Source: https://en.wikipedia.org/wiki/SOLID

### S.O.L.I.D: the five basic principles of object-oriented programming and design

The SOLID concepts are:

-	The Single-responsibility principle: "There should never be more than one reason for a class to change.". In other words, every class should have only one responsibility.

-	The Open-closed principle: "Software entities ... should be open for extension, but closed for modification."

-	The Liskov substitution principle: "Functions that use pointers or references to base classes must be able to use objects of derived classes without knowing it". See also design by contract.

-	The Interface segregation principle: "Many client-specific interfaces are better than one general-purpose interface."

-	The Dependency inversion principle: "Depend upon abstractions, not concretions." 


Source: https://en.wikipedia.org/wiki/SOLID


### Inversion of control (IoC) - the concept behind DI

This states that a class should not configure its dependencies statically but should be configured by some other class from outside.

It is the fifth principle of S.O.L.I.D which states that a class should depend on abstraction and not upon concretions (in simple terms, hard-coded).

According to the principles, a class should concentrate on fulfilling its responsibilities and not on creating objects that it requires to fulfill those responsibilities. And that's where dependency injection comes into play: it provides the class with the required objects.

``` csharp
/// <summary>
/// Class represents a car
/// </summary>
public class Car
{

    private readonly Engine _engine;

    /// <summary>
    /// Default cor
    /// </summary>
    public Car()
    {
        // Instanciated the engine here:tight coupled because _engine is not changeable
        _engine = new Engine();

    }

	...
}
```

The Engine class can't be replaced i.e. with another implementation or a fake for unit testing

``` csharp
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

	...

}
```

The Engine class can easily be replaced with another implementation or a fake for unit testing.

IoC makes only sense with the introduction of interfaces!

### Dependency injection (DI)

Dependency injection makes loose coupling of classes possible. The main question is: how do I get my required dependencies in a class from outside the class. Benefits of using DI are:
	
-	Helps in unit testing.

-	Boiler plate code is reduced, as initializing of dependencies is done by the injector component.

-	Extending the application becomes easier.

-	Helps to enable loose coupling, which is important in application programming.

There are basically three types of dependency injection:
	
-	constructor injection: the dependencies are provided through a class constructor.

-	setter injection: the client exposes a setter method that the injector uses to inject the dependency.

-	interface injection: the dependency provides an injector method that will inject the dependency into any client passed to it. Clients must 
implement an interface that exposes a setter method that accepts the dependency.

Service locator style of injection may be called a type of dependency injection too but its usage isn't recommend (see below).

### Constructor injection


The dependencies of a class are injected via the constructor of a class. This is the preferred way on dependency injection.


``` csharp
// Using default spellchecker	
IEngine engine = new XEngine()
var carWithEngineX = new Car(engine)

// Using another spellchecker
engine = new YEngine()
var carWithEngineY = new Car(engine)

// Using a fake for testing	
engine = new FakeEngine()
var carWithFakeEngine = new Car(engine)
```

### Service locator style of injection

Via a central dependency manager a required dependency is resolved from inside the class:

``` csharp
var instance = DependencyManager.GetInstance<ICar>()
```

This type of dependency injection works but is not very transparent from outside the class. Therefore it should by avoided and replaced by constructor injection.


# Inheritance

Imagine a class representing a car. As we all know there are a lot do different brands of cars. 
All these different types of cars have common properties, methods and events. Lets take the method "StartEngine" of a car. All cars will have such a functionality. 
But all types of cars will handle this functionality in a different manner.

Inheritance makes it possible to implement a common behaviour in a different manner.

## Simple inheritance

Simple inheritance is relatively easy to understand but not very helpfull in reality.

See the follwoing code:

``` csharp
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

/// <summary>
/// Base class car brand A
/// </summary>
public class CarBrandA: Car
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public CarBrandA()
    {
        ManufacturerName = "BrandACompany";
    }
}

/// <summary>
/// Brand A Model X car
/// </summary>
public class CarBrandAModelX : CarBrandA
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public CarBrandAModelX()
    {
        TypeName = "Model X";
    }
}

/// <summary>
/// Brand A Model X car
/// </summary>
public class CarBrandAModelY : CarBrandA
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CarBrandAModelY()
    {
        TypeName = "Model Y";
    }
}
```

See the following tests what simple inheritance is doing for you:

``` csharp
[Test]
public void Car_StartEngine_WriteTextinDebugWindow()
{
    // Arrange 
    var car = new Car();

    // Act  
    car.ManufacturerName = "BarndXY";
    car.TypeName = "Model xy";
    car.StartEngine();

    // Assert
    Assert.That(car, Is.Not.Null);
    // Writes: Engine of car model BarndXY Model xy starts...

}

[Test]
public void CarBrandA_StartEngine_WriteTextinDebugWindow()
{
    // Arrange 
    var car = new CarBrandA();

    // Act  
    car.TypeName = "Model xy";
    car.StartEngine();

    // Assert
    Assert.That(car, Is.Not.Null);
    // Writes: Engine of car model BrandACompany Model xy starts...

}


[Test]
public void CarBrandAModelX_StartEngine_WriteTextinDebugWindow()
{
    // Arrange 
    var car = new CarBrandAModelX();

    // Act  
    car.StartEngine();

    // Assert
    Assert.That(car, Is.Not.Null);
    // Writes: Engine of car model BrandACompany Model X starts...

}

[Test]
public void CarBrandAModelY_StartEngine_WriteTextinDebugWindow()
{
    // Arrange 
    var car = new CarBrandAModelY();

    // Act  
    car.StartEngine();

    // Assert
    Assert.That(car, Is.Not.Null);
    // Writes:Engine of car model BrandACompany Model Y starts...

}
```

Simple inheritance makes it possible to inherite properties, methods and events from a base class (here Car class). 
The weakness of simple inheritance is that you cannot change the behaviour of the base class implementation of i.e. a method (here StartEngine).
To add additional functionality to a class (subclass) inheriting from another class is possible.

## Inheritance with overriding

Overriding means you implement a property, a method or an event in a subclass in another manner then in the base class. Devs speak of "overriding a method/property/event"

Class intended as base class wil be marked "abtract" in the most cases as they normally do NOT represent a fully featured existing class.

Methods intended to be overriden have to marked as "virtual".


``` csharp
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

    /// <summary>
    /// Base class car brand A
    /// </summary>
    public abstract class CarBrandA : Car
    {

        /// <summary>
        /// Default ctor
        /// </summary>
        public CarBrandA()
        {
            ManufacturerName = "BrandACompany";
        }


    }

    /// <summary>
    /// Brand A Model X car
    /// </summary>
    public class CarBrandAModelX : CarBrandA
    {

        /// <summary>
        /// Default ctor
        /// </summary>
        public CarBrandAModelX()
        {
            TypeName = "Model X";
        }

        /// <summary>
        /// Start the engine of the car the way model X needs it
        /// </summary>
        public override void StartEngine()
        {
            // Start engine here
            Debug.Print($"Engine of car model {ManufacturerName} {TypeName} starts...");
            // Writes: 
        }

    }

    /// <summary>
    /// Brand A Model X car
    /// </summary>
    public class CarBrandAModelY : CarBrandA
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public CarBrandAModelY()
        {
            TypeName = "Model Y";
        }

        /// <summary>
        /// Start the engine of the car the way model Y needs it
        /// </summary>
        public override void StartEngine()
        {
            // Start engine here
            Debug.Print($"Engine of car model {ManufacturerName} {TypeName} starts...");
            // Writes: 
        }

    }
```

See the following tests what inheritance with overriding is doing for you:

```
 [Test]
 public void CarBrandAModelX_StartEngine_WriteTextinDebugWindow()
 {
     // Arrange 
     var car = new CarBrandAModelX();

     // Act  
     car.StartEngine();

     // Assert
     Assert.That(car, Is.Not.Null);
     // Writes: Engine of car model BrandACompany Model X starts...

 }

 [Test]
 public void CarBrandAModelY_StartEngine_WriteTextinDebugWindow()
 {
     // Arrange 
     var car = new CarBrandAModelY();

     // Act  
     car.StartEngine();

     // Assert
     Assert.That(car, Is.Not.Null);
     // Writes: Engine of car model BrandACompany Model Y starts...

 }
```


## Interfaces

Interfaces are contracts to describe which properties, methods and events a certain class of objects has to implement.

Using interfaces instead of concrete object classes makes code more flexible. 

``` csharp
    /// <summary>
    /// Interface for cr engine implementations
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Start the engine of the car
        /// </summary>
        void StartEngine();
    }

    /// <summary>
    /// Class representing the engine of the car
    /// </summary>
    public class Engine : IEngine
    {

        /// <summary>
        /// Start the engine of the car
        /// </summary>
        public void StartEngine()
        {
            // Start the engine here
        }

    }
```


# Basic development principles

## Methods

Methods should fulfill only one purpose.

A method should contain a maximum of 10 lines of code.


## Usage of constructors

Constructors (or short ctors) should be only only to setup the class and accept dependencies from outside for implementing the inversion of control principle (see below).

Ctors should not be used to do additional functionality like 

opening database or web connections
loading required data from class external data sources

Such funtionality should be located outside the ctor. This makes the class and the ctor more testable


## Dependency handling

### Tight coupled approach

The tight coupled approach is the approach you see often in beginner projects lacking knowledge.

``` csharp
    /// <summary>
    /// Class represents a car
    /// </summary>
    public class Car
    {

        private readonly Engine _engine;

        /// <summary>
        /// Default cor
        /// </summary>
        public Car()
        {
			// *********************************
            // Instanciated the engine here: tight coupled because _engine is not changeable
			// *********************************
            _engine = new Engine();

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

    public delegate void EngineStartedHandler(object sender, EngineStartedEventHandlerArgs args);

    /// <summary>
    /// Class representing the engine of the car
    /// </summary>
    public class Engine
    {

        /// <summary>
        /// Start the engine of the car
        /// </summary>
        public void StartEngine()
        {
            // Start the engine here
        }

    }

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
```

``` csharp

    private bool _wasEventFired;

    [Test]
    public void Car_StartEngine_EventEngineStartedFired()
    {
        // Arrange 
        _wasEventFired = false;

        var car = new Car
        {
            ManufacturerName = "BrandXY",
            TypeName = "Model XY"
        };

        // Register the even CarOnEngineStartedEvent
        car.EngineStartedEvent += CarOnEngineStartedEvent;

        // Act
        car.StartEngine();

        // Assert
        Wait.Until(() => _wasEventFired);

        Assert.That(_wasEventFired, Is.True);
    }

    private void CarOnEngineStartedEvent(object sender, EngineStartedEventHandlerArgs args)
    {
        Debug.Print(args.Message);
        _wasEventFired = true;
    }
```
	

### Loosely coupled approach with IoC and dependency injection (DI)

IoC means that not the consumer of a dependency is responsible for the creation of the dependency but the external environment of the consumer: the consumer gets the required dependencies "injected" via ctor.

Using IoC enhances flexibility and testability of the code. 

It improves the readability of the code and makes it easier to understand what the code is doing and what dependencies are required.

``` csharp

    /// <summary>
    /// Class represents a car
    /// </summary>
    public class Car
    {

        private readonly Engine _engine;

        /// <summary>
        /// Default cor
        /// </summary>
        public Car()
        {
            // Instanciated the engine here:tight coupled because _engine is not changeable
            _engine = new Engine();

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

    public delegate void EngineStartedHandler(object sender, EngineStartedEventHandlerArgs args);

    /// <summary>
    /// Class representing the engine of the car
    /// </summary>
    public class Engine
    {

        /// <summary>
        /// Start the engine of the car
        /// </summary>
        public void StartEngine()
        {
            // Start the engine here
        }

    }

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
```

``` csharp
    private bool _wasEventFired;

    [Test]
    public void Car_StartEngine_EventEngineStartedFired()
    {
        // Arrange 
        _wasEventFired = false;

        // Create the depencies now
        var engine = new Engine();

        // Create the instance of the target class now with injected dependency
        var car = new Car(engine)
        {
            ManufacturerName = "BrandXY",
            TypeName = "Model XY"
        };

        // Register the even CarOnEngineStartedEvent
        car.EngineStartedEvent += CarOnEngineStartedEvent;

        // Act
        car.StartEngine();

        // Assert
        Wait.Until(() => _wasEventFired);

        Assert.That(_wasEventFired, Is.True);
    }

    private void CarOnEngineStartedEvent(object sender, EngineStartedEventHandlerArgs args)
    {
        Debug.Print(args.Message);
        _wasEventFired = true;
    }
```

### Loosely coupled approach with IoC and dependency injection and interfaces (DI)

``` csharp
    /// <summary>
    /// Interface for car implementations
    /// </summary>
    public interface ICar
    {
        /// <summary>
        /// Event fired when engine is started
        /// </summary>
        event EngineStartedHandler EngineStartedEvent;

        /// <summary>
        /// Name of the car type
        /// </summary>

        string TypeName { get; set; }

        /// <summary>
        /// Manufacturer name
        /// </summary>
        string ManufacturerName { get; set; }

        /// <summary>
        /// Start the engine of the car
        /// </summary>
        void StartEngine();
    }

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

    /// <summary>
    /// Interface for cr engine implementations
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Start the engine of the car
        /// </summary>
        void StartEngine();
    }

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

    public delegate void EngineStartedHandler(object sender, EngineStartedEventHandlerArgs args);


    /// <summary>
    /// Class representing the engine of the car
    /// </summary>
    public class Engine : IEngine
    {

        /// <summary>
        /// Start the engine of the car
        /// </summary>
        public void StartEngine()
        {
            // Start the engine here
        }

    }
```

``` csharp


```

#### Loosely coupled approach with IoC and dependency injection and interfaces and overriding (DI)

``` csharp
    /// <summary>
    /// Interface for car implementations
    /// </summary>
    public interface ICar
    {
        /// <summary>
        /// Event fired when engine is started
        /// </summary>
        event EngineStartedHandler EngineStartedEvent;

        /// <summary>
        /// Name of the car type
        /// </summary>

        string TypeName { get; set; }

        /// <summary>
        /// Manufacturer name
        /// </summary>
        string ManufacturerName { get; set; }

        /// <summary>
        /// Start the engine of the car
        /// </summary>
        void StartEngine();
    }


    public delegate void EngineStartedHandler(object sender, EngineStartedEventHandlerArgs args);

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

    /// <summary>
    /// Interface for cr engine implementations
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Start the engine of the car
        /// </summary>
        void StartEngine();
    }

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

    /// <summary>
    /// Base class car brand A
    /// </summary>
    public abstract class CarBrandA : Car
    {

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="engine">Injected dependency</param>
        protected CarBrandA(IEngine engine): base(engine)
        {
            ManufacturerName = "BrandACompany";
        }
    }

    /// <summary>
    /// Brand A Model X car
    /// </summary>
    public class CarBrandAModelX : CarBrandA
    {

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="engine">Injected dependency</param>
        public CarBrandAModelX(IEngine engine): base(engine)
        {
            TypeName = "Model X";
        }

        /// <summary>
        /// Start the engine of the car the way model X needs it
        /// </summary>
        public override void StartEngine()
        {
            // Start engine here
            Debug.Print($"Engine of car model {ManufacturerName} {TypeName} starts...");
            // Writes: Engine of car model BrandACompany Model X starts...

            FireEngineStartedEvent();
        }

    }

    /// <summary>
    /// Brand A Model X car
    /// </summary>
    public class CarBrandAModelY : CarBrandA
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="engine">Injected dependency</param>
        public CarBrandAModelY(IEngine engine) : base(engine)
        {
            TypeName = "Model Y";
        }

        /// <summary>
        /// Start the engine of the car the way model Y needs it
        /// </summary>
        public override void StartEngine()
        {
            // Start engine here
            Debug.Print($"Engine of car model {ManufacturerName} {TypeName} starts...");
            // Writes: Engine of car model BrandACompany Model Y starts...

            FireEngineStartedEvent();
        }

    }



    /// <summary>
    /// Class representing the engine of the car
    /// </summary>
    public class Engine : IEngine
    {

        /// <summary>
        /// Start the engine of the car
        /// </summary>
        public void StartEngine()
        {
            // Start the engine here
        }

    }
```


``` csharp

    private bool _wasEventFired;

    [Test]
    public void CarBrandAModelX_StartEngine_EventEngineStartedFired()
    {
        // Arrange 
        _wasEventFired = false;

        // Create the depencies now
        var engine = new Engine();

        // Create the instance of the target class now with injected dependency
        var car = new CarBrandAModelX(engine);

        // Register the even CarOnEngineStartedEvent
        car.EngineStartedEvent += CarOnEngineStartedEvent;

        // Act
        car.StartEngine();

        // Assert
        Wait.Until(() => _wasEventFired);

        Assert.That(_wasEventFired, Is.True);
    }


    [Test]
    public void CarBrandAModelY_StartEngine_EventEngineStartedFired()
    {
        // Arrange 
        _wasEventFired = false;

        // Create the depencies now
        var engine = new Engine();

        // Create the instance of the target class now with injected dependency
        var car = new CarBrandAModelY(engine);

        // Register the even CarOnEngineStartedEvent
        car.EngineStartedEvent += CarOnEngineStartedEvent;

        // Act
        car.StartEngine();

        // Assert
        Wait.Until(() => _wasEventFired);

        Assert.That(_wasEventFired, Is.True);
    }

    private void CarOnEngineStartedEvent(object sender, EngineStartedEventHandlerArgs args)
    {
        Debug.Print(args.Message);
        _wasEventFired = true;
    }
```

### Loosely coupled approach using a DI container

A DI container is responsible is to store the information of all types of available objects in app and how to create it.

### Service locator pattern

The service locator is a pattern to call a dependency directly at the place the dependency is used.

You should try to avoid the usage of service locator pattern. It weakens readability and testability of code.

There are rare situations where you have to use the service locator pattern i.e. during setting up a dependency injection (DI) container.


``` csharp
public class TextEditor 
{ 
	private SpellChecker _checker; 

	///
	/// ctor
	///
	public TextEditor() 
	{ 

	} 
	
	public void DoSomething()
	{
	
		// Fetch the required dependeny from central app pool
		var checker = checker = DependencyPool.Get<SpellChecker>(); 		
	
		// Use the dependency now
		var result = checker.Check("Test spell chechker"");
	
		...
	}
}
