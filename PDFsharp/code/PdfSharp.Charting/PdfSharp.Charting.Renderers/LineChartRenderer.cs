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
using PdfSharp.Drawing;

namespace PdfSharp.Charting.Renderers
{
  /// <summary>
  /// Represents a line chart renderer.
  /// </summary>
  internal class LineChartRenderer : ColumnLikeChartRenderer
  {
    /// <summary>
    /// Initializes a new instance of the LineChartRenderer class with the specified renderer parameters.
    /// </summary>
    internal LineChartRenderer(RendererParameters parms) : base(parms)
    {
    }

    /// <summary>
    /// Returns an initialized and renderer specific rendererInfo.
    /// </summary>
    internal override RendererInfo Init()
    {
      ChartRendererInfo cri = new ChartRendererInfo();
      cri.chart = (Chart)this.rendererParms.DrawingItem;
      this.rendererParms.RendererInfo = cri;

      InitSeriesRendererInfo();

      LegendRenderer lr = new ColumnLikeLegendRenderer(this.rendererParms);
      cri.legendRendererInfo = (LegendRendererInfo)lr.Init();

      AxisRenderer xar = new HorizontalXAxisRenderer(this.rendererParms);
      cri.xAxisRendererInfo = (AxisRendererInfo)xar.Init();

      AxisRenderer yar = new VerticalYAxisRenderer(this.rendererParms);
      cri.yAxisRendererInfo = (AxisRendererInfo)yar.Init();

      PlotArea plotArea = cri.chart.PlotArea;
      LinePlotAreaRenderer lpar = new LinePlotAreaRenderer(this.rendererParms);
      cri.plotAreaRendererInfo = (PlotAreaRendererInfo)lpar.Init();

      return cri;
    }

    /// <summary>
    /// Layouts and calculates the space used by the line chart.
    /// </summary>
    internal override void Format()
    {
      ChartRendererInfo cri = (ChartRendererInfo)this.rendererParms.RendererInfo;

      LegendRenderer lr = new ColumnLikeLegendRenderer(this.rendererParms);
      lr.Format();

      // axes
      AxisRenderer xar = new HorizontalXAxisRenderer(this.rendererParms);
      xar.Format();

      AxisRenderer yar = new VerticalYAxisRenderer(this.rendererParms);
      yar.Format();

      // Calculate rects and positions.
      CalcLayout();

      // Calculated remaining plot area, now it's safe to format.
      LinePlotAreaRenderer lpar = new LinePlotAreaRenderer(this.rendererParms);
      lpar.Format();
    }

    /// <summary>
    /// Draws the line chart.
    /// </summary>
    internal override void Draw()
    {
      ChartRendererInfo cri = (ChartRendererInfo)this.rendererParms.RendererInfo;

      LegendRenderer lr = new ColumnLikeLegendRenderer(this.rendererParms);
      lr.Draw();

      // Draw wall.
      WallRenderer wr = new WallRenderer(this.rendererParms);
      wr.Draw();

      // Draw gridlines.
      GridlinesRenderer glr = new ColumnLikeGridlinesRenderer(this.rendererParms);
      glr.Draw();

      PlotAreaBorderRenderer pabr = new PlotAreaBorderRenderer(this.rendererParms);
      pabr.Draw();

      // Draw line chart's plot area.
      LinePlotAreaRenderer lpar = new LinePlotAreaRenderer(this.rendererParms);
      lpar.Draw();

      // Draw x- and y-axis.
      if (cri.xAxisRendererInfo.axis != null)
      {
        AxisRenderer xar = new HorizontalXAxisRenderer(this.rendererParms);
        xar.Draw();
      }

      if (cri.yAxisRendererInfo.axis != null)
      {
        AxisRenderer yar = new VerticalYAxisRenderer(this.rendererParms);
        yar.Draw();
      }
    }

    /// <summary>
    /// Initializes all necessary data to draw a series for a line chart.
    /// </summary>
    private void InitSeriesRendererInfo()
    {
      ChartRendererInfo cri = (ChartRendererInfo)this.rendererParms.RendererInfo;

      SeriesCollection seriesColl = cri.chart.SeriesCollection;
      cri.seriesRendererInfos = new SeriesRendererInfo[seriesColl.Count];
      for (int idx = 0; idx < seriesColl.Count; ++idx)
      {
        SeriesRendererInfo sri = new SeriesRendererInfo();
        sri.series = seriesColl[idx];
        cri.seriesRendererInfos[idx] = sri;
      }

      InitSeries();
    }

    /// <summary>
    /// Initializes all necessary data to draw a series for a line chart.
    /// </summary>
    internal void InitSeries()
    {
      ChartRendererInfo cri = (ChartRendererInfo)this.rendererParms.RendererInfo;

      int seriesIndex = 0;
      foreach (SeriesRendererInfo sri in cri.seriesRendererInfos)
      {
        if (sri.series.markerBackgroundColor.IsEmpty)
          sri.LineFormat = Converter.ToXPen(sri.series.lineFormat, LineColors.Item(seriesIndex), ChartRenderer.DefaultSeriesLineWidth);
        else
          sri.LineFormat = Converter.ToXPen(sri.series.lineFormat, sri.series.markerBackgroundColor, ChartRenderer.DefaultSeriesLineWidth);
        sri.LineFormat.LineJoin = XLineJoin.Bevel;

        MarkerRendererInfo mri = new MarkerRendererInfo();
        sri.markerRendererInfo = mri;

        mri.MarkerForegroundColor = sri.series.markerForegroundColor;
        if (mri.MarkerForegroundColor.IsEmpty)
          mri.MarkerForegroundColor = XColors.Black;

        mri.MarkerBackgroundColor = sri.series.markerBackgroundColor;
        if (mri.MarkerBackgroundColor.IsEmpty)
          mri.MarkerBackgroundColor = sri.LineFormat.Color;

        mri.MarkerSize = sri.series.markerSize;
        if (mri.MarkerSize == 0)
          mri.MarkerSize = 7;

        if (!sri.series.markerStyleInitialized)
          mri.MarkerStyle = (MarkerStyle)(seriesIndex % (Enum.GetNames(typeof(MarkerStyle)).Length - 1) + 1);
        else
          mri.MarkerStyle = sri.series.markerStyle;

        ++seriesIndex;
      }
    }
  }
}
