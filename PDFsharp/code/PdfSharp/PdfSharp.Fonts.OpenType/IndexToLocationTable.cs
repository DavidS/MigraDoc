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
using System.Collections;
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
  /// The indexToLoc table stores the offsets to the locations of the glyphs in the font,
  /// relative to the beginning of the glyphData table. In order to compute the length of
  /// the last glyph element, there is an extra entry after the last valid index. 
  /// </summary>
  internal class IndexToLocationTable : OpenTypeFontTable
  {
    public const string Tag = TableTagNames.Loca;

    internal int[] locaTable;

    public IndexToLocationTable()
      : base(null, Tag)
    {
      DirectoryEntry.Tag = TableTagNames.Loca;
    }

    public IndexToLocationTable(FontData fontData)
      : base(fontData, Tag)
    {
      DirectoryEntry = this.fontData.tableDictionary[TableTagNames.Loca];
      Read();
    }

    public bool ShortIndex;

    /// <summary>
    /// Converts the bytes in a handy representation
    /// </summary>
    public void Read()
    {
      try
      {
        ShortIndex = this.fontData.head.indexToLocFormat == 0;
        this.fontData.Position = DirectoryEntry.Offset;
        if (ShortIndex)
        {
          int entries = DirectoryEntry.Length / 2;
          Debug.Assert(this.fontData.maxp.numGlyphs + 1 == entries,
            "For your information only: Number of glyphs mismatch in font. You can ignore this assertion.");
          this.locaTable = new int[entries];
          for (int idx = 0; idx < entries; idx++)
            locaTable[idx] = 2 * this.fontData.ReadUFWord();
        }
        else
        {
          int entries = DirectoryEntry.Length / 4;
          Debug.Assert(this.fontData.maxp.numGlyphs + 1 == entries,
            "For your information only: Number of glyphs mismatch in font. You can ignore this assertion.");
          this.locaTable = new int[entries];
          for (int idx = 0; idx < entries; idx++)
            locaTable[idx] = this.fontData.ReadLong();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    /// Prepares the font table to be compiled into its binary representation.
    /// </summary>
    public override void PrepareForCompilation()
    {
      DirectoryEntry.Offset = 0;
      if (ShortIndex)
        DirectoryEntry.Length = this.locaTable.Length * 2;
      else
        DirectoryEntry.Length = this.locaTable.Length * 4;

      this.bytes = new byte[DirectoryEntry.PaddedLength];
      int length = this.locaTable.Length;
      int byteIdx = 0;
      if (ShortIndex)
      {
        for (int idx = 0; idx < length; idx++)
        {
          int value = this.locaTable[idx] / 2;
          this.bytes[byteIdx++] = (byte)(value >> 8);
          this.bytes[byteIdx++] = (byte)(value);
        }
      }
      else
      {
        for (int idx = 0; idx < length; idx++)
        {
          int value = this.locaTable[idx];
          this.bytes[byteIdx++] = (byte)(value >> 24);
          this.bytes[byteIdx++] = (byte)(value >> 16);
          this.bytes[byteIdx++] = (byte)(value >> 8);
          this.bytes[byteIdx++] = (byte)value;
        }
      }
      DirectoryEntry.CheckSum = CalcChecksum(this.bytes);
    }
    byte[] bytes;

    /// <summary>
    /// Converts the font into its binary representation.
    /// </summary>
    public override void Write(OpenTypeFontWriter writer)
    {
      writer.Write(this.bytes, 0, DirectoryEntry.PaddedLength);
    }
  }
}