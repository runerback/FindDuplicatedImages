using ImageMagick;

namespace DemoAndTest
{
    sealed class BlurStep : IGenerateStep
    {
        public string Name => "Blur";

        public void Apply(MagickImage image)
        {
            image.Blur(3, 99);
        }
    }
}
