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
	public class JoinActivity : Activity, ConnectionRequestListener, RoomRequestListener
	{
		private TextView name;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			base.OnCreate (bundle);
			//Use UI created in Main.axml
			SetContentView (Resource.Layout.Main);

			//Create the user interface in code
			var layout = new LinearLayout (this);
			layout.Orientation = Orientation.Vertical;

			name = FindViewById<TextView> (Resource.Id.input_name);

			var showSecond = FindViewById<Button> (Resource.Id.connectButton);
			showSecond.Click += (sender, e) => {
				WarpClient.GetInstance().Connect(name.Text);
			};

			WarpClient.initialize(Constants.API_KEY, Constants.SECRET_KEY);
			WarpClient.GetInstance().AddConnectionRequestListener(this);
			WarpClient.GetInstance().AddRoomRequestListener(this);
		}

		public void onConnectDone (ConnectEvent evt)
		{
			if (evt.getResult () == WarpResponseResultCode.SUCCESS) {
				Console.WriteLine ("Connection Successful");
				WarpClient.GetInstance().JoinRoom(Constants.CHAT_ROOM_ID);
			} else {
				Console.WriteLine ("Connection Failed");
			}
		}

		public void onInitUDPDone(byte result){

		}

		public void onDisconnectDone(ConnectEvent evt)
		{
			if (evt.getResult () == WarpResponseResultCode.SUCCESS) {
				Console.WriteLine ("Disconnect Successful");
			} else {
				Console.WriteLine ("Disconnect Failed");
			}
		}


		public void onGetLiveRoomInfoDone (LiveRoomInfoEvent eventObj)
		{
		}
		
		public void onJoinRoomDone (RoomEvent eventObj)
		{
			if (eventObj.getResult () == WarpResponseResultCode.SUCCESS) {
				WarpClient.GetInstance ().SubscribeRoom(Constants.CHAT_ROOM_ID);
			}
		}
		
		public void onLeaveRoomDone (RoomEvent eventObj)
		{
		}
		
		public void onSetCustomRoomDataDone (LiveRoomInfoEvent eventObj)
		{
		}
		
		public void onSubscribeRoomDone (RoomEvent eventObj)
		{
			if (eventObj.getResult () == WarpResponseResultCode.SUCCESS) {
				StartActivity(typeof(ChatActivity));
				this.Finish();
			}
		}
		
		public void onUnSubscribeRoomDone (RoomEvent eventObj)
		{
		}

		public void onUpdatePropertyDone(LiveRoomInfoEvent eventObj){

		}

		public void onLockPropertiesDone(byte result){
		}

		public void onUnlockPropertiesDone(byte result){
		}
	}
}


