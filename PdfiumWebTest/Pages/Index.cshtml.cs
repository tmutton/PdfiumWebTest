using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PDFiumSharp;

namespace PdfiumWebTest.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            // pdf extraction here
            using (var doc = new PdfDocument("c:\\test.pdf"))
            {
                int i = 0;
                foreach (var page in doc.Pages)
                {
                    using (var bitmap = new PDFiumBitmap((int)page.Width, (int)page.Height, true))
                    using (var stream = new FileStream($"{i++}.bmp", FileMode.Create))
                    {
                        page.Render(bitmap);
                        bitmap.Save(stream);
                    }
                }
            }
        }
    }
}
