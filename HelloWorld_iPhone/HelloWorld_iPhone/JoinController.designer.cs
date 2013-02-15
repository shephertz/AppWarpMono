// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace HelloWorld_iPhone
{
	[Register ("JoinController")]
	partial class JoinController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField nameTextField { get; set; }

		[Action ("onConnectClicked:")]
		partial void onConnectClicked (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (nameTextField != null) {
				nameTextField.Dispose ();
				nameTextField = null;
			}
		}
	}
}
