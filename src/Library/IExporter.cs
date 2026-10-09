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
    public interface IExporter
    {
        //Esta es la firma que comparten
         void GenerateFile(IList<Person> people, string outputPath);
    }

}