using System.Drawing;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tetris.Model.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void ANewGame_ShouldHave_20Rows()
        {
            const IPieceGenerator dontCare = null;

            // Act
            var game = new Game(dontCare);

            game.RowCount.Should().Be(20);
        }

        [TestMethod]
        public void ToCreateANewPiece_ThePieceGeneratorIsUsed()
        {
            var pieceGeneratorMock = new Mock<IPieceGenerator>();
            var myPiece = new Piece(Shape.Arrow, Color.Bisque);
            pieceGeneratorMock.Setup(pg => pg.GetNewPiece())
                              .Returns(() => myPiece);
            var game = new Game(pieceGeneratorMock.Object);
            game.Start();

            // Act
            game.Tick();    // This is the first tick in that new game. According to the AutomaticBehaviour.feature this creates a new piece

            pieceGeneratorMock.Verify(pg => pg.GetNewPiece(), Times.Once());
            game.CurrentPiece.Shape.Should().Be(myPiece.Shape);
            game.CurrentPiece.Color.Should().Be(myPiece.Color);
        }
    }
}
