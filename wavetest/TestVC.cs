using System;
using UIKit;

namespace WaveExample
{
  public class TestVC : UIViewController
  {
    public override void ViewDidLoad ()
    {
      View.BackgroundColor = UIColor.Yellow;

      var wave = new WaveView ();
      wave.Frame = UIScreen.MainScreen.Bounds;
      wave.Start ();

      View.AddSubview (wave);

      base.ViewDidLoad ();
    }
  }
}