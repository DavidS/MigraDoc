#region PDFsharp - A .NET library for processing PDF
//
// Authors:
//   Stefan Lange (mailto:Stefan.Lange@pdfsharp.com)
//
// Copyright (c) 2005-2009 empira Software GmbH, Cologne (Germany)
//
// http://www.pdfsharp.com
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

#define VERBOSE_

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Internal;

using Fixed = System.Int32;
using FWord = System.Int16;
using UFWord = System.UInt16;

namespace PdfSharp.Fonts.OpenType
{
  /// <summary>
  /// Represents an entry in the fonts table dictionary.
  /// </summary>
  class TableDirectoryEntry
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TableDirectoryEntry"/> class.
    /// </summary>
    public TableDirectoryEntry()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TableDirectoryEntry"/> class.
    /// </summary>
    public TableDirectoryEntry(string tag)
    {
      Debug.Assert(tag.Length == 4);
      Tag = tag;
      //CheckSum = 0;
      //Offset = 0;
      //Length = 0;
      //FontTable = null;
    }

    /// <summary>
    /// 4 -byte identifier.
    /// </summary>
    public string Tag;

    /// <summary>
    /// CheckSum for this table.
    /// </summary>
    public uint CheckSum;

    /// <summary>
    /// Offset from beginning of TrueType font file.
    /// </summary>
    public int Offset;

    /// <summary>
    /// Actual length of this table in bytes.
    /// </summary>
    public int Length;

    /// <summary>
    /// Gets the length rounded up to a multiple of four bytes.
    /// </summary>
    public int PaddedLength
    {
      get { return (Length + 3) & ~3; }
    }

    /// <summary>
    /// Associated font table.
    /// </summary>
    public OpenTypeFontTable FontTable;

    /// <summary>
    /// Creates and reads a TableDirectoryEntry from the font image.
    /// </summary>
    public static TableDirectoryEntry ReadFrom(FontData fontData)
    {
      TableDirectoryEntry entry = new TableDirectoryEntry();
      entry.Tag = fontData.ReadTag();
      entry.CheckSum = fontData.ReadULong();
      entry.Offset = fontData.ReadLong();
      entry.Length = (int)fontData.ReadULong();
      return entry;
    }

    public void Read(FontData fontData)
    {
      this.Tag = fontData.ReadTag();
      this.CheckSum = fontData.ReadULong();
      this.Offset = fontData.ReadLong();
      this.Length = (int)fontData.ReadULong();
    }

    public void Write(OpenTypeFontWriter writer)
    {
      Debug.Assert(this.Tag.Length == 4);
      Debug.Assert(this.Offset != 0);
      Debug.Assert(this.Length != 0);
      writer.WriteTag(this.Tag);
      writer.WriteUInt(this.CheckSum);
      writer.WriteInt(this.Offset);
      writer.WriteUInt((uint)this.Length);
    }
  }
}
