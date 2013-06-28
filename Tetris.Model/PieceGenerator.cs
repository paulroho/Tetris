using System;
using System.Collections.Generic;

namespace Tetris.Model
{
    public interface IPieceGenerator
    {
        Piece GetNewPiece();
    }

    public class PieceGenerator : IPieceGenerator
    {
        public Piece GetNewPiece()
        {
            var shape = GetRandomShape();
            return new Piece(shape);
        }

        private static Shape GetRandomShape()
        {
            return GetRandomValue((Shape[]) Enum.GetValues(typeof(Shape)));
        }

        static readonly Random Rand = new Random();

        private static T GetRandomValue<T>(IList<T> values)
        {
            lock (Rand)
            {
                return values[Rand.Next(values.Count)];
            }
        }
    }
}