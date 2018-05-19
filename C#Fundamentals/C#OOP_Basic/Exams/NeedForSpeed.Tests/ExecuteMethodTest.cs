using NUnit.Framework;
using NeedForSpeed.Core.IO;
using Moq;
using NeedForSpeed.Interfaces;
using NeedForSpeed.Interfaces.IO;

namespace NeedForSpeed.Tests
{
    [TestFixture]
    public class ExecuteMethodTest
    {

        [Test]
        public void TestValidConstructor()
        {
            ICarManager manager = new CarManager();

            //Arrange
            
            
            var engine = new ConsoleReader();
            Mock<CheckCommand> mock = new Mock<CheckCommand>();
            mock.Setup(m => m.Execute())
             .Returns("register 5 Performance Trabant 601 1988 2000 1 10000 1000");

           

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
