using System;
using FHSDK;
using UIKit;
using System.Collections.Generic;

namespace helloworldios
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			result.Text = "Loading...";
			await FHClient.Init();
			result.Text = "Response here.";
			button.TouchUpInside += async delegate {
				CallCloudAsync();
			};
		}

		public async void CallCloudAsync()
		{
			var response = await FH.Cloud ("hello", "GET", null, new Dictionary<string, string> () { { "hello", name.Text } });
			if (response.Error == null) {
				Console.WriteLine ("cloudCall - success");
				result.Text = (string)response.GetResponseAsDictionary () ["msg"];
			} else {
				Console.WriteLine ("cloudCall - fail");
				Console.WriteLine (response.Error.Message, response.Error);
				result.Text = response.Error.Message;
			}
		}
	}
}

