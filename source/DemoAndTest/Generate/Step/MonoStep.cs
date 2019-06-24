using ImageMagick;

namespace DemoAndTest
{
    sealed class MonoStep : IGenerateStep
    {
        public string Name => "Mono";

        public void Apply(MagickImage image)
        {
            image.Format = MagickFormat.Mono;
        }
    }
}
