#region PDFsharp Charting - A .NET charting library based on PDFsharp
//
// Authors:
//   Niklas Schneider (mailto:Niklas.Schneider@pdfsharp.com)
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

using System;
using System.ComponentModel;
using PdfSharp.Drawing;

namespace PdfSharp.Charting
{
  /// <summary>
  /// Represents a DataLabel of a Series
  /// </summary>
  public class DataLabel : DocumentObject
  {
    /// <summary>
    /// Initializes a new instance of the DataLabel class.
    /// </summary>
    public DataLabel()
    {
    }

    /// <summary>
    /// Initializes a new instance of the DataLabel class with the specified parent.
    /// </summary>
    internal DataLabel(DocumentObject parent) : base(parent) {}
    
    #region Methods
    /// <summary>
    /// Creates a deep copy of this object.
    /// </summary>
    public new DataLabel Clone()
    {
      return (DataLabel)DeepCopy();
    }

    /// <summary>
    /// Implements the deep copy of the object.
    /// </summary>
    protected override object DeepCopy()
    {
      DataLabel dataLabel = (DataLabel)base.DeepCopy();
      if (dataLabel.font != null)
      {
        dataLabel.font = dataLabel.font.Clone();
        dataLabel.font.parent = dataLabel;
      }
      return dataLabel;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets a numeric format string for the DataLabel.
    /// </summary>
    public string Format
    {
      get {return this.format;}
      set {this.format = value;}
    }
    internal string format = String.Empty;

    /// <summary>
    /// Gets the Font for the DataLabel.
    /// </summary>
    public Font Font
    {
      get
      {
        if (this.font == null)
          this.font = new Font(this);

        return this.font;
      }
    }    
    internal Font font;

    /// <summary>
    /// Gets or sets the position of the DataLabel.
    /// </summary>
    public DataLabelPosition Position
    {
      get {return (DataLabelPosition)this.position;}
      set
      {
        if (!Enum.IsDefined(typeof(DataLabelPosition), value))
          throw new InvalidEnumArgumentException("value", (int)value, typeof(DataLabelPosition));

        this.position = value;
        this.positionInitialized = true;
      }
    }
    internal DataLabelPosition position;
    internal bool positionInitialized;

    /// <summary>
    /// Gets or sets the type of the DataLabel.
    /// </summary>
    public DataLabelType Type
    {
      get {return (DataLabelType)this.type;}
      set
      {
        if (!Enum.IsDefined(typeof(DataLabelType), value))
          throw new InvalidEnumArgumentException("value", (int)value, typeof(DataLabelType));

        this.type = value;
        this.typeInitialized = true;
      }
    }
    internal DataLabelType type;
    internal bool typeInitialized;
    #endregion
  }
}