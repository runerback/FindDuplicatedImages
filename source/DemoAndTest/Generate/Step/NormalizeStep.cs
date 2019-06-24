using ImageMagick;

namespace DemoAndTest
{
    sealed class NormalizeStep : IGenerateStep
    {
        public string Name => "Normalize";

        public void Apply(MagickImage image)
        {
            image.Normalize();
        }
    }
}
