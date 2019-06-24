using ImageMagick;

namespace DemoAndTest
{
    sealed class EqualizeStep : IGenerateStep
    {
        public string Name => "Equalize";

        public void Apply(MagickImage image)
        {
            image.Equalize();
        }
    }
}
