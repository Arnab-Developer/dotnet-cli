using CreatedWithVs.Lib;
using Xunit;

namespace CreatedWithVs.LibTest
{
    public class HelloServiceTest
    {
        private readonly IHelloService _helloService;

        public HelloServiceTest()
        {
            _helloService = new HelloService();
        }

        [Fact]
        public void CanGetHelloMessageReturnProperMessage()
        {
            string userName = "jon";
            string helloMessage = _helloService.GetHelloMessage(userName);
            Assert.Equal("Hello jon", helloMessage);
        }
    }
}
