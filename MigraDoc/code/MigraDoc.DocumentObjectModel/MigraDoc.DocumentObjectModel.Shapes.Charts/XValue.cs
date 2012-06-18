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
using MigraDoc.DocumentObjectModel.Internals;

namespace MigraDoc.DocumentObjectModel.Shapes.Charts
{
  /// <summary>
  /// Represents the actual value on the XSeries.
  /// </summary>
  public class XValue : ChartObject
  {
    /// <summary>
    /// Initializes a new instance of the XValue class.
    /// </summary>
    internal XValue()
    {
    }

    /// <summary>
    /// Initializes a new instance of the XValue class with the specified value.
    /// </summary>
    public XValue(string value)
      : this()
    {
      if (value == null)
        throw new ArgumentNullException("value");

      this.Value = value;
    }

    /// <summary>
    /// The actual value of the XValue.
    /// </summary>
    [DV] // No Get- and Set -Property.
    protected string Value;

    #region Methods
    /// <summary>
    /// Creates a deep copy of this object.
    /// </summary>
    public new XValue Clone()
    {
      return (XValue)DeepCopy();
    }
    #endregion

    #region Internal
    /// <summary>
    /// Converts XValue into DDL.
    /// </summary>
    internal override void Serialize(Serializer serializer)
    {
      serializer.Write("\"" + this.Value + "\", ");
    }

    /// <summary>
    /// Returns the meta object of this instance.
    /// </summary>
    internal override Meta Meta
    {
      get
      {
        if (meta == null)
          meta = new Meta(typeof(XValue));
        return meta;
      }
    }
    static Meta meta;
    #endregion
  }
}
