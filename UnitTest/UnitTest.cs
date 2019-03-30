using LoginRadiusAssignment.API;
using LoginRadiusAssignment.Models;
using LoginRadiusAssignment.Models.Request;
using LoginRadiusAssignment.Models.Response;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class UnitTest
    {
        [Test]
        public void LoginTest()
        {
            var mock = new Moq.Mock<AccountController>();
            mock.Setup(x => x.Login(new GetUserRequestModel())).Returns(new CommandResponseModel());
            Assert.AreEqual(mock.Object.Login(new GetUserRequestModel()), true);
        }
        [Test]
        public void GetWeatherbyCityNameTest()
        {
            var mock = new Moq.Mock<WeatherBroadcastController>();
            mock.Setup(x => x.GetWeatherbyCityName(new WeatherMapRequestModel())).Returns(new CommandResponseModel());
            Assert.AreEqual(mock.Object.GetWeatherbyCityName(new WeatherMapRequestModel()), true);
        }
        [Test]
        public void GetWeatherbyZipTest()
        {
            var mock = new Moq.Mock<WeatherBroadcastController>();
            mock.Setup(x => x.GetWeatherbyZip(new WeatherMapRequestModel())).Returns(new CommandResponseModel());
            Assert.AreEqual(mock.Object.GetWeatherbyZip(new WeatherMapRequestModel()), true);
        }
    }
}
