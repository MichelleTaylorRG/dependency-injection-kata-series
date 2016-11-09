using DependencyInjection.Console.CharacterWriters;
using DependencyInjection.Console.Entities;
using DependencyInjection.Console.SquarePainters;
using NDesk.Options;

namespace DependencyInjection.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var useColors = false;
            var width = 25;
            var height = 15;
            var pattern = "circle"; // TODO: Hook this up

            var optionSet = new OptionSet
            {
                {"c|colors", value => useColors = value != null},
                {"w|width=", value => width = int.Parse(value)},
                {"h|height=", value => height = int.Parse(value)},
                {"p|pattern=", value => pattern = value}
            };
            optionSet.Parse(args);

            //Pile of constructors

            var baseWriter = new AsciiWriter();
            var characterWriter = useColors ? (ICharacterWriter)new ColorWriter(baseWriter) : baseWriter;
            
            var patternWriter = new PatternWriter(characterWriter);

            var circleSquarePainter = new CircleSquarePainter();

            var patternGenerator = new PatternGenerator(circleSquarePainter);

            var app = new PatternApp(patternWriter,patternGenerator);
            app.Run(new Pattern(width,height));
        }
    }
}
