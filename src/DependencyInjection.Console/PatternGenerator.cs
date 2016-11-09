using DependencyInjection.Console.Entities;
using DependencyInjection.Console.SquarePainters;

namespace DependencyInjection.Console
{
    internal class PatternGenerator
    {
        private readonly ISquarePainter _squarePainter;

        public PatternGenerator(ISquarePainter painter)
        {
            _squarePainter = painter;
        }

        public Pattern Generate(Pattern pattern)
        {
            var squares = pattern.Squares;

            var height = pattern.Squares.GetLength(0);
            var width = pattern.Squares.GetLength(1);

            for (var i = 0; i < width; ++i)
            {
                for (var j = 0; j < height; ++j)
                {
                    squares[j, i] = _squarePainter.PaintSquare(width, height, i, j);
                }
            }

            return pattern;
        }
    }
}