using System;
using System.Collections.Generic;
using System.Drawing;

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
            var color = GetRandomColor();
            return new Piece(shape, color);
        }

        private Color GetRandomColor()
        {
            return GetRandomValue(new[] {Color.Red, Color.Blue, Color.Yellow, Color.Green});
        }

        private static Shape GetRandomShape()
        {
            return GetRandomEnum<Shape>();
        }

        private static T GetRandomEnum<T>() where T:struct 
        {
            return GetRandomValue((T[]) Enum.GetValues(typeof(T)));
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