using DependencyInjection.Console.Entities;

namespace DependencyInjection.Console
{
    internal class PatternApp
    {
        private readonly PatternWriter _patternWriter;
        private readonly PatternGenerator _patternGenerator;

        public PatternApp(PatternWriter patternWriter, PatternGenerator patternGenerator)
        {
            _patternWriter = patternWriter;
            _patternGenerator = patternGenerator;
        }

        public void Run(Pattern pattern)
        {
            var generatedPattern = _patternGenerator.Generate(pattern);
            _patternWriter.Write(generatedPattern);
        }
    }
}