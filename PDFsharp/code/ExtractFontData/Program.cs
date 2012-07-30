using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Fonts.OpenType;

namespace ExtractFontData
{
  class Program
  {
    static void Main(string[] args)
    {
      FontDataConfig.SaveFont = true;

      XFont f;

      foreach (var name in args.Length > 0 ? args : new[] { "Arial", "Deja Vu Sans", "Microsoft Sans Serif", "Times New Roman", "Verdana" })
      {
        f = new XFont(name, 10);
        f = new XFont(name, 10, XFontStyle.Bold);
        f = new XFont(name, 10, XFontStyle.Italic);
      }
    }
  }
}
