using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Ucu.Poo.PersonExporter
{
    public class CSV : IExporter
    {
        public void GenerateFile(IList<Person> people, string outputPath)
        {
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
            {
                using (CsvWriter csv = new CsvWriter(writer, config))
                {
                    csv.WriteHeader<Person>();
                    csv.NextRecord();
                    csv.WriteRecords(people);
                }
            }
        }
    }
}

