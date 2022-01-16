using MachiKoro.Api.Contracts.Game.GetGame;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Api.UnitTests.Game
{
    [TestFixture]
    public class GameTests
    {
        private Mock<IMediator> _mockMediator;
        private Mock<HttpRequest> _mockHttpRequest;

        [SetUp]
        public void SetUp()
        {
            _mockMediator = new Mock<IMediator>(MockBehavior.Strict);
            _mockHttpRequest = new Mock<HttpRequest>(MockBehavior.Strict);
        }

        [TearDown]
        public void TearDown()
        {
            _mockMediator.VerifyNoOtherCalls();
        }

        [Test]
        public async Task GetAllGames_Should_Return_Games()
        {
        }

        [Test]
        public async Task GetGameById_Should_Return_Game()
        {
        }

        [Test]
        public async Task GetGameById_Should_Throw_Game_Not_Found()
        {
        }
    }
}