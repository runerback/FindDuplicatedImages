using ImageMagick;

namespace DemoAndTest
{
    sealed class ModulateStep : IGenerateStep
    {
        public string Name => "Modulate";

        public void Apply(MagickImage image)
        {
            image.Modulate(new Percentage(100));
        }
    }
}
