using ImageMagick;
using System;

namespace DemoAndTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var generator = new FingerprintGenerator();
                using (var source = new ImageSource())
                {
                    while (source.Next(out string imgFile))
                    {
                        generator.Generate(imgFile);
                    }
                }

                Console.WriteLine("done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.ReadKey(true);
            }
        }
    }
}
