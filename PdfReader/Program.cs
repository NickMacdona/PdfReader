using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

class Program
{
    // Path to the PDF file
    static readonly string filepath = "example.pdf";
    static List<PdfDocument> files = new List<PdfDocument>();


    static void Main(string[] args)
    {
        ReadPdf(filepath);
        WriteToConsole();
    }

    static Boolean WriteToConsole()
    {
        foreach (PdfDocument document in files)
        {
            for (int i = 1; i <= document.GetNumberOfPages(); i++)
            {
                string pageText = ExtractTextFromPage(document, i);
                Console.WriteLine("Page " + i + " Text:");
                Console.WriteLine(pageText);
            }
        }

        return true;
    }

    static Boolean WriteToFile()
    {
        foreach (PdfDocument document in files)
        {
            for (int i = 1; i <= document.GetNumberOfPages(); i++)
            {
                string pageText = ExtractTextFromPage(document, i);
                Console.WriteLine("Page " + i + " Text:");
                Console.WriteLine(pageText);
            }
        }

        return true;
    }

    static Boolean ReadPdf(string file)
    {
        PdfReader pdfReader = new PdfReader(file);

        int countbefore = files.Count;
        files.Add(new PdfDocument(pdfReader));
        int countafter = files.Count;
        if (countafter == (countbefore + 1))
        {
            return true;
        }

        return false;

    }

    static string ExtractTextFromPage(PdfDocument pdfDocument, int pageNumber)
    {
        SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
        PdfPage page = pdfDocument.GetPage(pageNumber);
        string pageText = PdfTextExtractor.GetTextFromPage(page, strategy);

        return pageText;
    }
}
