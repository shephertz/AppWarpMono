using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.message;

namespace HelloM4A
{
	[Activity (Label = "HelloM4A", MainLauncher = true)]
	public class Activity1 : Activity, ConnectionRequestListener
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//Create the user interface in code
			var layout = new LinearLayout (this);
			layout.Orientation = Orientation.Vertical;
			
			var aLabel = new TextView (this);
			aLabel.Text = "Hello, Mono for Android";
			
			var aButton = new Button (this);      
			aButton.Text = "Join Zone";
			aButton.Click += (sender, e) => {
				WarpClient.GetInstance().Connect();
			};  
			layout.AddView (aLabel);
			layout.AddView (aButton);           
			SetContentView (layout);
			WarpClient.initialize("Your API Key", 
			                      "Your Secret Key");
			WarpClient.GetInstance().AddConnectionRequestListener(this);
		}

		public void onConnectDone (ConnectEvent evt)
		{
			if (evt.getResult () == WarpResponseResultCode.SUCCESS) {
				Console.WriteLine ("Connection Successful");
				WarpClient.GetInstance().JoinZone("dhruv");
			} else {
				Console.WriteLine ("Connection Failed");
			}
		}

		public void onJoinZoneDone (ConnectEvent evt)
		{
			if (evt.getResult () == WarpResponseResultCode.SUCCESS) {
				Console.WriteLine ("JoinZone Successful");
			} else {
				Console.WriteLine ("JoinZone Failed");
			}
		}

		public void onDisconnectDone(ConnectEvent evt)
		{
			if (evt.getResult () == WarpResponseResultCode.SUCCESS) {
				Console.WriteLine ("Disconnect Successful");
			} else {
				Console.WriteLine ("Disconnect Failed");
			}
		}
	}
}


