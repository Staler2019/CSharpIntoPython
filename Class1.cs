using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CSharpIntoPython;

public static class Class1
{
    public static string HelloWorld()
    {
        return "Hello World!";
    }

    public static void WriteToDocx(string fileFullPath, string strToWrite)
    {
        using (var doc = WordprocessingDocument.Open(fileFullPath, true))
        {
            var altChunkId = "cid";
            var mainDocPart = doc.MainDocumentPart;
            var body = mainDocPart.Document.Body;

            var inject = $"<p>{strToWrite}</p>";
            var injectStr = $"<html><head></head><body>{inject}</body></html>";

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(injectStr));
            var importPart = mainDocPart.AddAlternativeFormatImportPart(
                AlternativeFormatImportPartType.Html
                , altChunkId);
            importPart.FeedData(ms);

            var altChunk = new AltChunk();
            altChunk.Id = altChunkId;

            body.Append(altChunk);
        }
    }
}
