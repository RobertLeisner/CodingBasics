// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using CodingBasics.Inheritance.C01_Simple_Inheritance;

namespace CodingBasics.Tests.Inheritance
{
    [TestFixture]
    internal class SimpleInheritanceTests
    {


        [Test]
        public void Car_StartEngine_WriteTextinDebugWindow()
        {
            // Arrange 
            var car = new Car();

            // Act  
            car.ManufacturerName = "BrandXY";
            car.TypeName = "Model xy";
            car.StartEngine();

            // Assert
            Assert.That(car, Is.Not.Null);
            // Writes: Engine of car model BrandXY Model xy starts...

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

    }
}
