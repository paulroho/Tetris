using System.Collections.Generic;
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
            var generator = new PieceGenerator();
            var pieces1 = new List<Piece>();

            // Act
            Execute.This(() =>
                {
                    var newPiece = generator.GetNewPiece();
                    pieces1.Add(newPiece);
                }, 50.Times());
            var pieces = (IEnumerable<Piece>) pieces1;

            // Assert
            pieces.Should().NotHaveTheSame(p => p.Shape);
        }
    }
}
