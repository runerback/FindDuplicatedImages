using ImageMagick;

namespace DemoAndTest
{
    sealed class ThresholdStep : IGenerateStep
    {
        public string Name => "Threshold";

        public void Apply(MagickImage image)
        {
            image.Threshold(new Percentage(60));
        }
    }
}
