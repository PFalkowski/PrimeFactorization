using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Text;

namespace PrimeFactorization
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var factorizer = new OptimizedPrimeFactorizer();
            var lowerBound = 3; //int.MaxValue / 1000;
            var upperBound = int.MaxValue / 10000;
            var outFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"output {lowerBound}-{upperBound}.csv");
            const char separator = ',';
            var beginningTimeStamp = DateTime.Now;
            using (FileStream sourceStream = new FileStream(outFile, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                var encodedHeaders = Encoding.Unicode.GetBytes($"Number,Milliseconds,Factor1,Factor2,Factor3,Factor4,Factor5,Factor6,Factor7,Factor8,Factor9,Factor10,Factor11,Factor12{Environment.NewLine}");
                await sourceStream.WriteAsync(encodedHeaders, 0, encodedHeaders.Length);
                for (int i = lowerBound; i < upperBound; ++i)
                {
                    var timeStamp1 = DateTime.Now;
                    var result = factorizer.Factorize(i);
                    var timeStamp2 = DateTime.Now;
                    var stringbuilder = new StringBuilder();
                    stringbuilder.Append($"{i}{separator}");
                    stringbuilder.Append($"{(timeStamp2 - timeStamp1).TotalMilliseconds}{separator}");
                    stringbuilder.Append(string.Join(separator, result));
                    stringbuilder.AppendLine();
                    var lineToAppend = stringbuilder.ToString();
                    //Console.WriteLine($"Prime factors for {i} found: {lineToAppend}");
                    var encodedText = Encoding.Unicode.GetBytes(lineToAppend);
                    await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                }
            }
            var endTimeStamp = DateTime.Now;
            Console.WriteLine($"Factorized {upperBound - lowerBound} numbers in {endTimeStamp - beginningTimeStamp}");
        }
    }
}
