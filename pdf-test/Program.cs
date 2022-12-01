using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using RazorLight;
using RazorLight.Extensions;
using System;
using System.Threading.Tasks;

namespace pdf_test_app;

internal static class Program
{
    private class ViewModel
    {
        public string? Name { get; set; }
    }

    private class Template
    {
        public string? Content { get; set; }
        public string? Id { get; set; }
    }

    private static async Task<string?> ApplyTemplate(IRazorLightEngine engine, Template template,
        Type model_type, object model)
    {
        var expando_model_model = model.ToExpando();
        var result = await engine.CompileRenderStringAsync(template.Id, template.Content, expando_model_model);
        return result;
    }

    private static async Task Main(string[] args)
    {
        // Initialize razor engine
        var razor_engine = new RazorLightEngineBuilder()
            .UseEmbeddedResourcesProject(typeof(ViewModel)) // Any type in this solution will work
            .UseMemoryCachingProvider()
            .DisableEncoding()
            .Build();

        const string output_file_name = "Test.pdf";
        var model = new ViewModel { Name = "Kevin Weis" };
        var template = new Template
        {
            Id = "6080746d-9334-4b0d-832e-0be625bb3ce7",
            Content = @"
@using System.Linq

<html>
<head>
  <title>Some Title</title>
  <meta charset=""UTF-8"">
</head>

<body>
<h1>Some Headline</h1>
<h2>Welcome to Razor templating</h2>

@foreach (var i in Enumerable.Range(1, 5))
{
    <p>[@i] Hello, @Model.Name.</p>
}
</body>
"
        };

        var converter_properties = new ConverterProperties();
        converter_properties.SetCharset("unicode");

        var pdf_writer = new PdfWriter(output_file_name);
        pdf_writer.SetCompressionLevel(9);

        var pdf_document = new PdfDocument(pdf_writer);
        pdf_document.AddNewPage(PageSize.A4);

        var html_string = await ApplyTemplate(razor_engine, template, typeof(ViewModel), model);

        HtmlConverter.ConvertToPdf(html_string, pdf_document, converter_properties);
    }
}
