using ImageMagick;

namespace DemoAndTest
{
    sealed class FirstResampleStep : IGenerateStep
    {
        private const int FIRST_SAMPLE_SIZE = 160;

        public string Name => "First Resample";

        public void Apply(MagickImage image)
        {
            var size = new MagickGeometry(FIRST_SAMPLE_SIZE)
            {
                IgnoreAspectRatio = true
            };
            image.Sample(size);
        }
    }
}
