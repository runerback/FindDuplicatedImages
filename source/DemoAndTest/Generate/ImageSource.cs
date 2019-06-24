using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DemoAndTest
{
    sealed class ImageSource : IDisposable
    {
        private const string source_path = "../../../../data/Images/";
        private readonly IEnumerator<string> iterator;

        public ImageSource()
        {
            if (!Directory.Exists(source_path))
                iterator = Enumerable.Empty<string>().GetEnumerator();
            else
                iterator = Directory.GetFiles(source_path)//, "*.jpg|*.jpeg|*.png")
                    .AsEnumerable()
                    .GetEnumerator();
        }

        public bool Next(out string imgFilePath)
        {
            imgFilePath = null;

            if (disposed)
                return false;

            if (iterator.MoveNext())
            {
                imgFilePath = iterator.Current;
                return true;
            }
            return false;
        }

        private bool disposed = false;
        public void Dispose()
        {
            if (disposed)
                return;

            iterator.Dispose();
            disposed = true;
        }
    }
}
