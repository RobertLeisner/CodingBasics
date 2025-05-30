// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Moq;

namespace CodingBasics.Tests.Moq
{
    [TestFixture]
    internal class MoqDemoTests
    {
        [Test]
        public void DoSomeThingWithReturnValue_TwoStrings_ReturnsConcatenatedString()
        {
            // Arrange
            const string inputA = "This is an ";
            const string inputB = "example";
            const string expectedResult = "This is an example";

            var mockService = new Mock<IDoSomethingService>();
            mockService.Setup(x => x.DoSomeThingWithReturnValue(inputA, inputB)).Returns(expectedResult);

            var demo = new DemoClass(mockService.Object);

            // Act
            var result = demo.CreateString(inputA, inputB);

            // Assert
            // Assert returned value is as expected
            Assert.That(result, Is.EqualTo(expectedResult));

            // Assert method called only onces
            mockService.Verify(m => m.DoSomeThingWithReturnValue(inputA, inputB), Times.Once());
        }

        [Test]
        public void DoSomethingWith_DefaultSetup_PropertyChanged()
        {
            // Arrange
            const bool expectedResult = true;

            var mockService = new Mock<IDoSomethingService>();
            mockService.Setup(x => x.Changed).Returns(false);
            mockService.Setup(x => x.DoSomething())
                .Callback(() => mockService.SetupGet(y => y.Changed).Returns(true));

            var demo = new DemoClass(mockService.Object);

            // Act
            demo.DoSomething();

            // Assert
            // Assert property is changed as expected
            Assert.That(mockService.Object.Changed, Is.EqualTo(expectedResult));

            // Assert method called only onces
            mockService.Verify(m => m.DoSomething(), Times.Once());

        }

    }
}
