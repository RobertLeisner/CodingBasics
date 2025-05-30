// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.


// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using CodingBasics.Inheritance.C02_Inheritance_with_overriding;

namespace CodingBasics.Tests.Inheritance
{
    [TestFixture]
    internal class InheritanceWithOverridingTests
    {


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

    }
}
