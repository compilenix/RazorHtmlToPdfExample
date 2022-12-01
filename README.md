create new .Net Framework 8.1 / .Net 6 console application

install Nuget Packages:
- itext7.pdfhtml
- RazorLight

update csproj by adding the following:
```xml
<PropertyGroup>
    <!-- This group contains project properties for RazorLight on .NET Core -->
    <PreserveCompilationContext>true</PreserveCompilationContext>
    <MvcRazorCompileOnPublish>false</MvcRazorCompileOnPublish>
    <MvcRazorExcludeRefAssembliesFromPublish>false</MvcRazorExcludeRefAssembliesFromPublish>
</PropertyGroup>

<PropertyGroup>
    <LangVersion>10.0</LangVersion>
</PropertyGroup>
```

reload project

build and run code

further reading:
RazorLight (Razor engine usage outside of ASP.NET): https://github.com/toddams/RazorLight
This might also work: https://codeopinion.com/using-razor-in-a-console-application/
Razor & E-Mail templates: https://scottsauber.com/2018/07/07/walkthrough-creating-an-html-email-template-with-razor-and-razor-class-libraries-and-rendering-it-from-a-net-standard-class-library/
Razor syntax reference: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor
iText 7 docs and guides: https://kb.itextpdf.com/home/it7kb
Hello HTML to PDF: https://kb.itextpdf.com/home/it7kb/ebooks/itext-7-converting-html-to-pdf-with-pdfhtml/chapter-1-hello-html-to-pdf


