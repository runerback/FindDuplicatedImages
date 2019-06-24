using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;

namespace DemoAndTest
{
    sealed class FingerprintGenerator
    {
        private const string output_path = "fingerprint";

        private readonly IGenerateStep[] steps = new IGenerateStep[]
        {
            new FirstResampleStep(),
            new ModulateStep(),
            new BlurStep(),
            new NormalizeStep(),
            new EqualizeStep(),
            new FinalResampleStep(),
            new ThresholdStep(),
            new MonoStep()
        };

        public void Generate(string imgFile)
        {
            if (string.IsNullOrWhiteSpace(imgFile))
                throw new ArgumentNullException(nameof(imgFile));
            if (!File.Exists(imgFile))
                throw new FileNotFoundException(imgFile);

            Console.WriteLine($"Reading {Path.GetFileName(imgFile)} . . .");
            using (var stream = ReadAsCopy(imgFile))
            using (var image = new MagickImage(stream))
            {
                foreach (var step in steps)
                {
                    Console.WriteLine($"{step.Name} . . .");
                    step.Apply(image);
                }

                Console.WriteLine("Saving . . .");
                SaveTo(image, imgFile);
            }
        }

        private Stream ReadAsCopy(string imgFile)
        {
            var stream = new MemoryStream();

            using (var fileStream = new FileStream(
                imgFile,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read))
            {
                fileStream.CopyTo(stream);
            }

            stream.Position = 0;

            return stream;
        }

        private void SaveTo(MagickImage image, string imgFile)
        {
            if (!Directory.Exists(output_path))
                Directory.CreateDirectory(output_path);

            var outputFile = $"{output_path }/{Path.GetFileNameWithoutExtension(imgFile)}.raw";
            using (var stream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                image.Write(stream);
            }
        }
    }
}
