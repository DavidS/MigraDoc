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
  /// Renders the plot area used by line charts. 
  /// </summary>
  internal class LinePlotAreaRenderer : ColumnLikePlotAreaRenderer
  {
    /// <summary>
    /// Initializes a new instance of the LinePlotAreaRenderer class with the
    /// specified renderer parameters.
    /// </summary>
    internal LinePlotAreaRenderer(RendererParameters parms) : base(parms)
    {
    }

    /// <summary>
    /// Draws the content of the line plot area.
    /// </summary>
    internal override void Draw()
    {
      ChartRendererInfo cri = (ChartRendererInfo)this.rendererParms.RendererInfo;

      XRect plotAreaRect = cri.plotAreaRendererInfo.Rect;
      if (plotAreaRect.IsEmpty)
        return;

      XGraphics gfx = this.rendererParms.Graphics;
      XGraphicsState state = gfx.Save();
      //gfx.SetClip(plotAreaRect, XCombineMode.Intersect);
      gfx.IntersectClip(plotAreaRect);

      //TODO null-Values m�ssen ber�cksichtigt werden.
      //     Verbindungspunkte k�nnen fehlen, je nachdem wie null-Values behandelt werden sollen.
      //     (NotPlotted, Interpolate etc.)

      // Draw lines and markers for each data series.
      XMatrix matrix = cri.plotAreaRendererInfo.matrix;

      double xMajorTick = cri.xAxisRendererInfo.MajorTick;
      foreach (SeriesRendererInfo sri in cri.seriesRendererInfos)
      {
        int count = sri.series.Elements.Count;
        XPoint[] points = new XPoint[count];
        for (int idx = 0; idx < count; idx++)
        {
          double v = sri.series.Elements[idx].Value;
          if (double.IsNaN(v))
            v = 0;
          points[idx] = new XPoint(idx + xMajorTick / 2, v);
        }
        matrix.TransformPoints(points);
        gfx.DrawLines(sri.LineFormat, points);
        DrawMarker(gfx, points, sri);
      }

      //gfx.ResetClip();
      gfx.Restore(state);
    }

    /// <summary>
    /// Draws all markers given in rendererInfo at the positions specified by points.
    /// </summary>
    private void DrawMarker(XGraphics graphics, XPoint[] points, SeriesRendererInfo rendererInfo)
    {
      foreach (XPoint pos in points)
        MarkerRenderer.Draw(graphics, pos, rendererInfo.markerRendererInfo);
    }
  }
}
