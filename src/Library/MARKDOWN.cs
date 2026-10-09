using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ucu.Poo.PersonExporter
{
    public class MARKDOWN : IExporter
    {
        public void GenerateFile(IList<Person> people, string outputPath)
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
    }
}