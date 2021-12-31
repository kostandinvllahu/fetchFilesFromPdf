using Aspose.Pdf;
using System;
using System.IO;

namespace FetchXmlFromPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            Document pdfDocument = new Document("pdf.pdf");

            // Get particular embedded file
            foreach (FileSpecification fileSpecification in pdfDocument.EmbeddedFiles)
            {
                // Get the file properties
                Console.WriteLine("Name: {0}", fileSpecification.Name);
                Console.WriteLine("Description: {0}", fileSpecification.Description);
                Console.WriteLine("Mime Type: {0}", fileSpecification.MIMEType);

                // Check if parameter object contains the parameters
                if (fileSpecification.Params != null)
                {
                    Console.WriteLine("CheckSum: {0}",
                    fileSpecification.Params.CheckSum);
                    Console.WriteLine("Creation Date: {0}",
                    fileSpecification.Params.CreationDate);
                    Console.WriteLine("Modification Date: {0}",
                    fileSpecification.Params.ModDate);
                    Console.WriteLine("Size: {0}", fileSpecification.Params.Size);
                }

                // Get the attachment and write to file or stream
                byte[] fileContent = new byte[fileSpecification.Contents.Length];
                fileSpecification.Contents.Read(fileContent, 0, fileContent.Length);

                FileStream fileStream = new FileStream(fileSpecification.Name, FileMode.Create);
                fileStream.Write(fileContent, 0, fileContent.Length);
                fileStream.Close();
            }
        }
    }
}
