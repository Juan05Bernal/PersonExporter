using System;
using System.Collections.Generic;
using System.Globalization;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Ucu.Poo.PersonExporter
{
    public class PDF : IExporter
    {
        public void GenerateFile(IList<Person> people, string outputPath)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            IDocument document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4);
                    page.PageColor("#FFFFFF");

                    page.Header()
                        .Text("Person Report")
                        .SemiBold().FontSize(20).AlignCenter();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(150);
                            columns.ConstantColumn(150);
                            columns.ConstantColumn(50);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(this.CellStyle).Text("First Name");
                            header.Cell().Element(this.CellStyle).Text("Last Name");
                            header.Cell().Element(this.CellStyle).Text("Age");
                        });

                        foreach (Person person in people)
                        {
                            table.Cell().Element(this.CellStyle).Text(person.FirstName);
                            table.Cell().Element(this.CellStyle).Text(person.LastName);
                            table.Cell().Element(this.CellStyle).Text(person.Age.ToString(CultureInfo.InvariantCulture));
                        }
                    });

                    page.Footer()
                        .AlignRight()
                        .Text(text =>
                        {
                            text.Span("Generated at: ");
                            text.Span(DateTime.Now.ToString("u"));
                        });
                });
            });

            document.GeneratePdf(outputPath);
        }   // <- aquí se cierra GenerateFile

        private IContainer CellStyle(IContainer container)
        {
            return container
                .Padding(4)
                .Border(1)
                .BorderColor("#CCCCCC");
        }
    }
}