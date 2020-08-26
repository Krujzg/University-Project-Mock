using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockPractice.Practice;
using Moq;
using NUnit.Framework;

namespace ClientTests
{
    [TestFixture]
    public class ClientTests
    {
        Mock<IService> mockService;
        Mock<IContentFormatter> mockContentFormatter;
        Client client;
        [SetUp]
        public void Setup()
        {
            mockService = new Mock<IService>();
            mockContentFormatter = new Mock<IContentFormatter>();
            mockService.SetupGet(m => m.Name).Returns("");

            client = new Client(mockService.Object, mockContentFormatter.Object);
        }
        [Test]
        public void GetIdentityFormatted_Should_Return_FormattedString_When_Called()
        {
            var result = client.GetIdentityFormatted();

            Assert.IsTrue(result.StartsWith("<formatted>"));
            Assert.IsTrue(result.EndsWith("</formatted>"));
            //Assert.AreEqual(result, "<formatted> ? </formatted>");
        }

        [Test]
        public void GetServiceName_Should_Return_EmptyString_When_Called()
        {
            var result = client.GetServiceName();

            Assert.AreEqual(result, "");
            mockService.Verify(m => m.Name, Times.Once);
        }


        [Test]
        public void GetContent_Should_OpenNewConnect_When_NoConnectionIsOpenAtCallTime()
        {
            var mockservice = new Mock<IService>();
            mockservice.SetupGet(m => m.IsConnected).Returns(true);
            
            client.GetContent(0);

            mockservice.Verify(m => m.Connect(), Times.Never);
            
        }


        [Test]
        public void GetContent_Should_Return_ContentString_When_GetContentIsCalled()
        {
            var id = 123;
            var content = "content";
            mockService.Setup(x => x.GetContent(It.IsAny<long>())).Returns(content);

            var result = client.GetContent(id);

            mockService.Verify(m => m.GetContent(id), Times.Once);
            Assert.AreEqual(result, content);
        }

        //HomeWork
        //GetContentFormatted // Dispose

        [TestCase("content")]
        public void GetContentFormatted_Should_CallOnce_GetContent_When_Called(string content)
        {
            var id = 123;
            client.GetContentFormatted(id);
            mockService.Verify(m => m.GetContent(id), Times.Once);

        }

        [TestCase]
        public void GetContentFormatted_Should_CallOnce_FormatMethod_When_Called()
        {
            var id = 123;
            client.GetContentFormatted(id);
            mockContentFormatter.Verify(m => m.Format(It.IsAny<string>()), Times.Once);

        }

        [TestCase]
        public void GetContentFormatted_Should_Return_formattedcontent_When_Called()
        {
            mockContentFormatter.Setup(x => x.Format(It.IsAny<string>())).Returns("formattedcontent");
            var id = 123;
            var result = client.GetContentFormatted(id);

            Assert.AreEqual(result, "formattedcontent");

        }

        [TestCase("content")]
        public void GetContentFormatted_Should_Return_FormattedString_When_GetContentCalledWithcontentParam(string content)
        {
            mockService.Setup(x => x.GetContent(It.IsAny<long>())).Returns(content);
            mockContentFormatter.Setup(x => x.Format(content)).Returns("formattedcontent");
            var id = 123;
            var result = client.GetContentFormatted(id);

            Assert.AreEqual(result, "formattedcontent");

        }

        [TestCase]
        public void Dispose_Should_CallOnce_ServiceDispose_When_Called()
        {
            client.Dispose();
            mockService.Verify(m => m.Dispose(), Times.Once);
        }



    }
}
