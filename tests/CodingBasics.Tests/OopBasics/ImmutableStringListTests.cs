// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using CodingBasics.OopBasics;

namespace CodingBasics.Tests.OopBasics;

[TestFixture]
internal class ImmutableStringListTests
{
    [Test]
    public void Ctor_DefaultSetup_PropsSetCorrectly()
    {
        // Arrange 

        // Act  
        var isl = new ImmutableStringList();

        // Assert
        Assert.That(isl.Count, Is.EqualTo(0));
        Assert.That(isl.AllItems.Count, Is.EqualTo(0));
    }

    [Test]
    public void AddString_DefaultSetup_StringAdded()
    {
        // Arrange 
        var isl = new ImmutableStringList();

        const string value = "Blubb";

        // Act  
        isl.AddString(value);

        // Assert
        Assert.That(isl.Count, Is.EqualTo(1));
        Assert.That(isl.AllItems.Count, Is.EqualTo(1));
        Assert.That(isl.AllItems[0], Is.EqualTo(value));
    }

    [Test]
    public void AddString_TwoStrings_StringAdded()
    {
        // Arrange 
        var isl = new ImmutableStringList();

        const string value = "Blubb";
        const string value2 = "Blabb";

        // Act  
        isl.AddString(value);
        isl.AddString(value2);

        // Assert
        Assert.That(isl.Count, Is.EqualTo(2));
        Assert.That(isl.AllItems.Count, Is.EqualTo(2));
        Assert.That(isl.AllItems[0], Is.EqualTo(value));
        Assert.That(isl.AllItems[1], Is.EqualTo(value2));
    }
}