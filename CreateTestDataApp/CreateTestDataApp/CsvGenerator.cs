using CsvHelper;
using System.Globalization;

namespace CreateTestDataApp
{
    internal static class CsvGenerator
    {
        internal static void Generate<T>(List<T> records, string path) where T : class
        {
            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteHeader<T>();
            csv.NextRecord();
            foreach (var record in records)
            {
                csv.WriteRecord(record);
                csv.NextRecord();
            }
        }
    }
}
