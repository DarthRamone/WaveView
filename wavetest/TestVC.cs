using System;
using UIKit;

namespace WaveExample
{
  public class TestVC : UIViewController
  {
	WaveView wave;

    public override void ViewDidLoad ()
    {
      View.BackgroundColor = UIColor.Yellow;

      wave = new WaveView ();
      wave.Frame = UIScreen.MainScreen.Bounds;

      View.AddSubview (wave);

      base.ViewDidLoad ();
    }

	public override void ViewDidAppear (bool animated)
	{
		base.ViewDidAppear (animated);
		wave.Start ();
	}
  }
}