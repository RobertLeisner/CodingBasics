// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.Tests.Moq;

public class DemoClass
{

    private readonly IDoSomethingService _service;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="service">Injcted service dependecy</param>
    public DemoClass(IDoSomethingService service)
    {
        _service = service;
    }


    /// <summary>
    /// Create a smaple string
    /// </summary>
    /// <returns>Sample string</returns>
    public string CreateString(string a, string b)
    {

        string result;

        // Do other things here

        result = _service.DoSomeThingWithReturnValue(a, b);

        // Do other things here

        return result;
    }

    /// <summary>
    /// Run an action
    /// </summary>
    public void DoSomething()
    {
        _service.DoSomething();
    }
}