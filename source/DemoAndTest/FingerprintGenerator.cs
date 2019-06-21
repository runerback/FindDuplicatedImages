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
        private const int FIRST_SAMPLE_SIZE = 160;

        public void Generate(string imgFile)
        {
            if (string.IsNullOrWhiteSpace(imgFile))
                throw new ArgumentNullException(nameof(imgFile));
            if (!File.Exists(imgFile))
                throw new FileNotFoundException(imgFile);

            using (var stream = ReadCopy(imgFile))
            using (var image = new MagickImage(stream))
            {
                FirstResample(image);


            }
        }

        private Stream ReadCopy(string imgFile)
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
            return stream;
        }

        private void SaveTo(MagickImage image, string imgFile)
        {
            var output = $"{Path.GetFileNameWithoutExtension(imgFile)}_fingerprint.{Path.GetExtension(imgFile)}";
            throw new NotImplementedException();
        }

        private void FirstResample(MagickImage image)
        {
            var size = new MagickGeometry(FIRST_SAMPLE_SIZE)
            {
                IgnoreAspectRatio = true
            };
            image.Resize(size);
        }
    }
}
