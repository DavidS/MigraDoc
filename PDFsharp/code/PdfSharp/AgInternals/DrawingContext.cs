using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

#if SILVERLIGHT
namespace System.Windows.Media
{
  internal class DrawingContext
  {
    internal DrawingContext()
    {}
    public void Close()
    {}
    //public void DrawDrawing(Drawing drawing);
    //public void DrawEllipse(Brush brush, Pen pen, Point center, double radiusX, double radiusY);
    //public void DrawEllipse(Brush brush, Pen pen, Point center, AnimationClock centerAnimations, double radiusX, AnimationClock radiusXAnimations, double radiusY, AnimationClock radiusYAnimations);
    public void DrawGeometry(Brush brush, Pen pen, Geometry geometry)
    {}
    //public void DrawGlyphRun(Brush foregroundBrush, GlyphRun glyphRun);
    //public void DrawImage(ImageSource imageSource, Rect rectangle);
    //public void DrawImage(ImageSource imageSource, Rect rectangle, AnimationClock rectangleAnimations);
    //public void DrawLine(Pen pen, Point point0, Point point1);
    //public void DrawLine(Pen pen, Point point0, AnimationClock point0Animations, Point point1, AnimationClock point1Animations);
    public void DrawRectangle(Brush brush, Pen pen, Rect rectangle)
    {}
    //public void DrawRectangle(Brush brush, Pen pen, Rect rectangle, AnimationClock rectangleAnimations);
    //public void DrawRoundedRectangle(Brush brush, Pen pen, Rect rectangle, double radiusX, double radiusY);
    //public void DrawRoundedRectangle(Brush brush, Pen pen, Rect rectangle, AnimationClock rectangleAnimations, double radiusX, AnimationClock radiusXAnimations, double radiusY, AnimationClock radiusYAnimations);
    //public void DrawText(FormattedText formattedText, Point origin);
    //public void DrawVideo(MediaPlayer player, Rect rectangle);
    //public void DrawVideo(MediaPlayer player, Rect rectangle, AnimationClock rectangleAnimations);
    //public void Pop();
    //public void PushClip(Geometry clipGeometry);
    //public void PushEffect(BitmapEffect effect, BitmapEffectInput effectInput);
    //public void PushGuidelineSet(GuidelineSet guidelines);
    //public void PushOpacity(double opacity);
    //public void PushOpacity(double opacity, AnimationClock opacityAnimations);
    //public void PushOpacityMask(Brush opacityMask);
    //public void PushTransform(Transform transform);
  }

  internal sealed class Pen //: Animatable
  {
    //// Fields
    //public static readonly DependencyProperty BrushProperty;
    //public static readonly DependencyProperty DashCapProperty;
    //public static readonly DependencyProperty DashStyleProperty;
    //public static readonly DependencyProperty EndLineCapProperty;
    //public static readonly DependencyProperty LineJoinProperty;
    //public static readonly DependencyProperty MiterLimitProperty;
    //public static readonly DependencyProperty StartLineCapProperty;
    //public static readonly DependencyProperty ThicknessProperty;

    //// Methods
    //public Pen();
    //public Pen(Brush brush, double thickness);
    //public Pen Clone();
    //public Pen CloneCurrentValue();

    //// Properties
    //public Brush Brush { get; set; }
    //public PenLineCap DashCap { get; set; }
    //public DashStyle DashStyle { get; set; }
    //public PenLineCap EndLineCap { get; set; }
    //public PenLineJoin LineJoin { get; set; }
    //public double MiterLimit { get; set; }
    //public PenLineCap StartLineCap { get; set; }
    //public double Thickness { get; set; }
  }
}
#endif