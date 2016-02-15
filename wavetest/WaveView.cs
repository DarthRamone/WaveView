using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace WaveExample
{
  public class WaveView : UIView
  {
    public nfloat WaveSpeed = 6f;
    public nfloat WaveAmplitude = 12f;

    nfloat waterWaveHeight;
    nfloat waterWaveWidth;
    nfloat offsetX;

    CADisplayLink waveDisplaylink;
    CAShapeLayer waveLayer;
    UIBezierPath waveBoundaryPath;

    public WaveView ()
    {
      BackgroundColor = UIColor.Clear;
      Layer.MasksToBounds = true;
      waterWaveHeight = UIScreen.MainScreen.Bounds.Height / 2;
      waterWaveWidth = UIScreen.MainScreen.Bounds.Width;
    }

    public void Start ()
    {
      waveBoundaryPath = new UIBezierPath ();

      waveLayer = new CAShapeLayer ();
      waveLayer.FillColor = new CGColor (0, 0, 0, 1);
      Layer.AddSublayer (waveLayer);
      waveDisplaylink = CADisplayLink.Create (() => GetCurrentWave (waveDisplaylink));
	  waveDisplaylink.AddToRunLoop (NSRunLoop.Main, NSRunLoop.NSDefaultRunLoopMode);
    }

    public void Stop ()
    {
      waveDisplaylink.Invalidate ();
      waveDisplaylink = null;
    }

    void GetCurrentWave (CADisplayLink displayLink)
    {
      offsetX += WaveSpeed;
      waveLayer.Path = GetCurrentWavePath ();
      waveBoundaryPath.CGPath = waveLayer.Path;
    }

    CGPath GetCurrentWavePath ()
    {
      var path = new CGPath ();
      path.MoveToPoint (0, waterWaveHeight);
      nfloat y = 0.0f;
      for (float x = 0.0f; x <= waterWaveWidth; x++) {
        y = WaveAmplitude * (float)Math.Sin ((360 / waterWaveWidth) * (x * Math.PI / 180) - offsetX * Math.PI / 180) + waterWaveHeight;
        path.AddLineToPoint (x, y);
      }

      path.AddLineToPoint (waterWaveWidth, Frame.Height);
      path.AddLineToPoint (0, Frame.Height);
      path.CloseSubpath ();

      return path;
    }
  }
}