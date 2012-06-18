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

namespace MigraDoc.DocumentObjectModel
{
  /// <summary>
  /// Specifies the style of the line of the Border object.
  /// </summary>
  public enum BorderStyle
  {
    /// <summary>
    /// No border.
    /// </summary>
    None,
    /// <summary>
    /// A single solid line.
    /// </summary>
    Single,
    /// <summary>
    /// A dotted line.
    /// </summary>
    Dot,
    /// <summary>
    /// A dashed line (small gaps).
    /// </summary>
    DashSmallGap,
    /// <summary>
    /// A dashed line (large gaps).
    /// </summary>
    DashLargeGap,
    /// <summary>
    /// Alternating dashes and dots.
    /// </summary>
    DashDot,
    /// <summary>
    /// A dash followed by two dots.
    /// </summary>
    DashDotDot,
    /* --- unsupported ---
      Double                = 7,
      Triple                = 8,
      ThinThickSmallGap     = 9,
      ThickThinSmallGap     = 10,
      ThinThickThinSmallGap = 11,
      ThinThickMedGap       = 12,
      ThickThinMedGap       = 13,
      ThinThickThinMedGap   = 14,
      ThinThickLargeGap     = 15,
      ThickThinLargeGap     = 16,
      ThinThickThinLargeGap = 17,
      SingleWavy            = 18,
      DoubleWavy            = 19,
      DashDotStroked        = 20,
      Emboss3D              = 21,
      Engrave3D             = 22,
      LineStyleOutset       = 23, //!!!newEG 02-07-22
      LineStyleInset        = 24  //!!!newEG 02-07-22
    */
  }
}
