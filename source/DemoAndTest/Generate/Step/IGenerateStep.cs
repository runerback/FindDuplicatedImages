namespace DemoAndTest
{
    interface IGenerateStep
    {
        string Name { get; }
        void Apply(ImageMagick.MagickImage image);
    }
}
