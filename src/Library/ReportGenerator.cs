//------------------------------------------------------------------------------
// <copyright file="ReportGenerator.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

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
    /// <summary>
    /// Genera reportes de personas en distintos formatos: PDF y HTML.
    /// </summary>
    public class ReportGenerator
    {
        /// <summary>
        /// Genera un reporte de una lista de personas en el formato indicado.
        /// </summary>
        /// <param name="people">Lista de personas a incluir en el
        /// reporte.</param>
        /// <param name="format">Formato de salida del reporte. Valores
        /// esperados: "PDF" o "HTML".</param>
        /// <param name="outputPath">Ruta completa del archivo de salida que se
        /// va a generar.</param>
        /// <returns>Retorna <c>true</c> si los reportes fueron generados y
        /// <c>false</c> en caso contrario.</returns>
        /// TODO: en lugar de recibir una string con el formato, recibir un objeto IExporter que ya sabe como exportar a ese formato
        public bool GenerateReport(IList<Person> people, IExporter exporter, string outputPath)
        {
            if (people == null)
            {
                return false;
            }
            if (exporter == null)
            {
                return false;
            }

            // if (string.IsNullOrWhiteSpace(format))
            // {
            //     return false;
            // }

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                return false;
            }

            exporter.GenerateFile(people, outputPath);
            return true;

            // format = format.Trim().ToUpperInvariant();

            // if (format == "HTML")
            // {
            //     this.GenerateHtml(people, outputPath);
            //     return true;
            // }
            // else if (format == "PDF")
            // {
            //     this.GeneratePdf(people, outputPath);
            //     return true;
            // }
            // else if (format == "MARKDOWN")
            // {
            //     this.GenerateMarkdown(people, outputPath);
            //     return true;
            // }
            // else
            // {
            //     return false;
            // }
        }

        private void GenerateMarkdown(IList<Person> people, string outputPath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# Person Report");
            sb.AppendLine();
            sb.AppendLine("| First Name | Last Name | Age |");
            sb.AppendLine("|-----------|-----------|-----|");

            foreach (Person person in people)
            {
                sb.AppendLine($"| {EscapeMarkdown(person.FirstName)} | {EscapeMarkdown(person.LastName)} | {person.Age} |");
            }

            string markdown = sb.ToString();
            File.WriteAllText(outputPath, markdown, Encoding.UTF8);
        }

        // Escapa caracteres especiales de Markdown en un texto simple.
        private static string EscapeMarkdown(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            string[] charsToEscape = new[] { "|", "*", "_", "`" };
            string result = value;

            foreach (string c in charsToEscape)
            {
                result = result.Replace(c, "\\" + c, StringComparison.Ordinal);
            }

            return result;
        }

        // Genera un archivo HTML con una tabla de personas.
        
        // Genera un archivo PDF con una tabla básica de personas.
        

        // Aplica el estilo común de celda para la tabla del PDF.
        
    }
}
