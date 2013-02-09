using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.util;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.command;
using AppWarp_WP7_TestSDK;

namespace HelloWorld_iPhone
{

	public partial class HelloWorld_iPhoneViewController : UIViewController, ConnectionRequestListener, ChatRequestListener, UpdateRequestListener
	{
		// Get your keys and room id from AppHQ console. http://apphq.shephertz.com
		public String roomId = "Your Room ID"; 
		private String api = "Your API Key";
		private String secret = "Your Secret Key";

		protected int _numberOfTimesClicked = 0;
		public HelloWorld_iPhoneViewController () : base ("HelloWorld_iPhoneViewController", null)
		{
			WarpClient.initialize(api, secret);
			WarpClient.GetInstance().AddConnectionRequestListener(this);
			WarpClient.GetInstance().AddLobbyRequestListener(new LobbyReqListen(this));
			WarpClient.GetInstance().AddRoomRequestListener(new RoomReqListener(this));
			WarpClient.GetInstance().AddNotificationListener(new NotificationListener(this));
			WarpClient.GetInstance().AddZoneRequestListener(new ZoneReqListener(this));

		}

		public void showResult (String message)
		{
			InvokeOnMainThread (delegate { 
				lblOutput.Text = message;
			});
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

			this.btnClickMe.TouchUpInside += (sender, e) => {
				WarpClient.GetInstance().Connect();
					_numberOfTimesClicked++;
					//lblOutput.Text = "Clicked [" + _numberOfTimesClicked.ToString() + "] times!";
			};
			// Perform any additional setup after loading the view, typically from a nib.
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
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		partial void actnButtonClick (NSObject sender)
		{
			//String value = System.Web.HttpUtility.UrlEncode("ASdf/?98");
			this.lblOutput.Text = "Action button " +  ((UIButton)sender).CurrentTitle + " clicked. ";
		}

		public void onConnectDone(ConnectEvent eventObj)
		{
			if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
			{
				showResult("Connect Succeeded!");
				WarpClient.GetInstance().JoinZone("dhruv");
			}
			else
			{
				showResult("Connect Failed!");
			}			
		}
		
		public void onJoinZoneDone(ConnectEvent eventObj)
		{
			if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
			{
				showResult("Join Succeeded!");
				WarpClient.GetInstance().JoinRoom(roomId);
			}
			else
			{
				showResult("Join Failed!");
			}
		}
		public void onDisconnectDone(ConnectEvent eventObj)
		{
		}

		public void onSendChatDone (byte result)
		{
		}

		public void onSendUpdateDone(byte result){

		}
	}
}

