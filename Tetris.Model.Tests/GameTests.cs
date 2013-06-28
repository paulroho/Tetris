using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tetris.Model.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void ToCreateANewPiece_ThePieceGeneratorIsUsed()
        {
            var pieceGeneratorMock = new Mock<IPieceGenerator>();
            var myPiece = new Piece();
            pieceGeneratorMock.Setup(pg => pg.GetNewPiece())
                              .Returns(() => myPiece);
            var game = new Game(pieceGeneratorMock.Object);
            game.Start();

            // Act
            game.Tick();    // This is the first tick in that new game. According to the AutomaticBehaviour.feature this creates a new piece

            pieceGeneratorMock.Verify(pg => pg.GetNewPiece(), Times.Once());
            game.CurrentPiece.Should().Be(myPiece);
        }
    }
}
