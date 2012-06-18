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
using System.Diagnostics;
using PdfSharp.Drawing;

namespace PdfSharp.Charting.Renderers
{
  /// <summary>
  /// Represents a Y axis renderer used for charts of type Column2D or Line.
  /// </summary>
  internal class VerticalStackedYAxisRenderer : VerticalYAxisRenderer
  {
    /// <summary>
    /// Initializes a new instance of the VerticalYAxisRenderer class with the
    /// specified renderer parameters.
    /// </summary>
    internal VerticalStackedYAxisRenderer(RendererParameters parms) : base(parms)
    {
    }

    /// <summary>
    /// Determines the sum of the smallest and the largest stacked column
    /// from all series of the chart.
    /// </summary>
    protected override void CalcYAxis(out double yMin, out double yMax)
    {
      yMin = double.MaxValue;
      yMax = double.MinValue;

      ChartRendererInfo cri = (ChartRendererInfo)this.rendererParms.RendererInfo;

      int maxPoints = 0;
      foreach (SeriesRendererInfo sri in cri.seriesRendererInfos)
        maxPoints = Math.Max(maxPoints, sri.series.seriesElements.Count);

      for (int pointIdx = 0; pointIdx < maxPoints; ++pointIdx)
      {
        double valueSumPos = 0, valueSumNeg = 0;
        foreach (SeriesRendererInfo sri in cri.seriesRendererInfos)
        {
          if (sri.pointRendererInfos.Length <= pointIdx)
            break;

          ColumnRendererInfo column = (ColumnRendererInfo)sri.pointRendererInfos[pointIdx];
          if (column.point != null && !double.IsNaN(column.point.value))
          {
            if (column.point.value < 0)
              valueSumNeg += column.point.value;
            else
              valueSumPos += column.point.value;
          }
        }
        yMin = Math.Min(valueSumNeg, yMin);
        yMax = Math.Max(valueSumPos, yMax);
      }
    }
  }
}
