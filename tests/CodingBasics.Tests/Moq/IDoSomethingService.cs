// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.Tests.Moq;

public interface IDoSomethingService
{

    /// <summary>
    /// Property changed by <see cref="DoSomething"/>
    /// </summary>
    bool Changed { get; set; }


    /// <summary>
    /// Do something and return a string
    /// </summary>
    /// <param name="a">String A</param>
    /// <param name="b">String B</param>
    /// <returns>String A concatenated with string B</returns>
    string DoSomeThingWithReturnValue(string a, string b);



    /// <summary>
    /// Do something without return a value;
    /// </summary>
    void DoSomething();

}