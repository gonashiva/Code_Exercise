using System;
using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }

        [Fact]
        public void CanBind_Exception_Test()
        {
            var container = new Container();
            Assert.Throws<ArgumentException>(() => container.Bind(typeof(IContainerTestInterface), typeof(Container)));
        }

        [Fact]
        public void CanGet_Exception_Test()
        {
            var container = new Container();
            Assert.Throws<InvalidOperationException>(() => container.Get<Container>());
        }
    }
}