using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;

namespace MachiKoro.Api.UnitTests.Game;

[TestFixture]
public class PlayerGameTests
{
    private Mock<IMediator> _mockMediator;

    [SetUp]
    public void SetUp()
    {
        _mockMediator = new Mock<IMediator>(MockBehavior.Strict);
    }

    [TearDown]
    public void TearDown()
    {
        _mockMediator.VerifyNoOtherCalls();
    }


}