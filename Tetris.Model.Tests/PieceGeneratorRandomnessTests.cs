using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.Model.Tests.Tools;

namespace Tetris.Model.Tests
{
    [TestClass]
    public class PieceGeneratorRandomnessTests
    {
        [TestMethod]
        public void GetNewPiece_ReturnsPiecesOfRandomShape()
        {
            // Act
            var pieces = GetRandomPieces();

            // Assert
            pieces.Should().NotHaveTheSame(p => p.Shape);
        }

        [TestMethod]
        public void GetNewPiece_ReturnsPiecesOfRandomColor()
        {
            // Act
            var pieces = GetRandomPieces();

            // Assert
            pieces.Should().NotHaveTheSame(p => p.Color);
        }

        [TestMethod]
        public void GetNewPiece_ReturnsPiecesOfRandomOrientation()
        {
            // Act
            var pieces = GetRandomPieces();

            // Assert
            pieces.Should().NotHaveTheSame(p => p.Orientation);
        }

        private static IEnumerable<Piece> GetRandomPieces()
        {
            var generator = new PieceGenerator();
            var pieces = new List<Piece>();
            
            Execute.This(() =>
                {
                    var newPiece = generator.GetNewPiece();
                    pieces.Add(newPiece);
                }, 50.Times());

            return pieces;
        }
    }
}
