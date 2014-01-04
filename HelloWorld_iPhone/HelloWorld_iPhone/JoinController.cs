
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.util;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.command;


namespace HelloWorld_iPhone
{
	public partial class JoinController : UIViewController, ConnectionRequestListener, RoomRequestListener
	{
		public JoinController () : base ("JoinController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			WarpClient.GetInstance().AddConnectionRequestListener(this);
			WarpClient.GetInstance().AddRoomRequestListener(this);

			this.View.BackgroundColor= UIColor.FromPatternImage(UIImage.FromFile("game_background.png"));
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}

		partial void onConnectClicked (NSObject sender)
		{
			if(WarpClient.GetInstance().GetConnectionState() == WarpConnectionState.DISCONNECTED)
			{
				Console.WriteLine("Connecting as "+this.nameTextField.Text);
				WarpClient.GetInstance().Connect(this.nameTextField.Text);
			}
			else
			{
				ChatController cc = new ChatController();
				this.NavigationController.PushViewController(cc, true);
			}
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		public void onConnectDone(ConnectEvent eventObj)
		{
			Console.WriteLine("onConnectDone as "+eventObj.getResult());
			if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
			{
				Console.WriteLine("Joining Room "+Constants.CHAT_ROOM_ID);
				WarpClient.GetInstance().JoinRoom(Constants.CHAT_ROOM_ID);
			}		
		}
		
		public void onInitUDPDone(byte result)
		{

		}
		public void onDisconnectDone(ConnectEvent eventObj)
		{
		}

		public void onSubscribeRoomDone(RoomEvent eventObj)
		{
			Console.WriteLine("onSubscribeRoomDone as "+eventObj.getResult());
			if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
			{
				InvokeOnMainThread (delegate { 
					nameTextField.ResignFirstResponder();
					ChatController cc = new ChatController();
					this.NavigationController.PushViewController(cc, true);
				});
			}
		}
		
		public void onUnSubscribeRoomDone(RoomEvent eventObj)
		{
		}
		
		public void onJoinRoomDone(RoomEvent eventObj)
		{
			Console.WriteLine("onJoinRoomDone as "+eventObj.getResult());
			if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
			{    
				Console.WriteLine("Subscribing Room "+Constants.CHAT_ROOM_ID);
				WarpClient.GetInstance().SubscribeRoom(Constants.CHAT_ROOM_ID);
			}
		}
		
		public void onLeaveRoomDone(RoomEvent eventObj)
		{
		}
		
		public void onGetLiveRoomInfoDone(LiveRoomInfoEvent eventObj)
		{         
		}

		public void onUpdatePropertyDone(LiveRoomInfoEvent eventObj){}

		public void onLockPropertiesDone(byte result){
		}

		public void onUnlockPropertiesDone(byte result){
		}

		public void onSetCustomRoomDataDone(LiveRoomInfoEvent eventObj)
		{
		}

	}
}

