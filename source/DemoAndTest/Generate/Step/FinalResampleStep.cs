using ImageMagick;

namespace DemoAndTest
{
    sealed class FinalResampleStep : IGenerateStep
    {
        private const int FINAL_SAMPLE_SIZE = 16;

        public string Name => "Final Resample";

        public void Apply(MagickImage image)
        {
            var size = new MagickGeometry(FINAL_SAMPLE_SIZE);
            image.Sample(size);
        }
    }
}
