#region MigraDoc - Creating Documents on the Fly
//
// Authors:
//   Stefan Lange (mailto:Stefan.Lange@pdfsharp.com)
//   Klaus Potzesny (mailto:Klaus.Potzesny@pdfsharp.com)
//   David Stephensen (mailto:David.Stephensen@pdfsharp.com)
//
// Copyright (c) 2001-2009 empira Software GmbH, Cologne (Germany)
//
// http://www.pdfsharp.com
// http://www.migradoc.com
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using System;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.DocumentObjectModel.Internals;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;

namespace MigraDoc.DocumentObjectModel.Visitors
{
  /// <summary>
  /// Represents the visitor for flattening the DocumentObject to be used in the RtfRenderer.
  /// </summary>
  public class RtfFlattenVisitor : VisitorBase
  {
    public RtfFlattenVisitor()
    {
    }

    internal override void VisitFormattedText(FormattedText formattedText)
    {
      Document document = formattedText.Document;
      ParagraphFormat format = null;

      Style style = document.styles[formattedText.style.Value];
      if (style != null)
        format = style.paragraphFormat;
      else if (formattedText.style.Value != "")
        format = document.styles["InvalidStyleName"].paragraphFormat;

      if (format != null)
      {
        if (formattedText.font == null)
          formattedText.Font = format.font.Clone();
        else if (format.font != null)
          FlattenFont(formattedText.font, format.font);
      }
    }

    internal override void VisitHyperlink(Hyperlink hyperlink)
    {
      Font styleFont = hyperlink.Document.Styles["Hyperlink"].Font;
      if (hyperlink.font == null)
        hyperlink.Font = styleFont.Clone();
      else
        FlattenFont(hyperlink.font, styleFont);
    }
  }
}
