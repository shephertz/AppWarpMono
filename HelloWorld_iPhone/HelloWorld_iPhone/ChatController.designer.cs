// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace HelloWorld_iPhone
{
	[Register ("ChatController")]
	partial class ChatController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField inputTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel historyLabel { get; set; }

		[Action ("onSendClicked:")]
		partial void onSendClicked (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (inputTextField != null) {
				inputTextField.Dispose ();
				inputTextField = null;
			}

			if (historyLabel != null) {
				historyLabel.Dispose ();
				historyLabel = null;
			}
		}
	}
}
