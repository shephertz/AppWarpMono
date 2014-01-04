
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client;

namespace HelloM4A
{
	[Activity (Label = "ChatActivity")]			
	public class ChatActivity : Activity, NotifyListener
	{
		private TextView chatHistory;
		private Button sendButton;

		private ChatMessage[] history = new ChatMessage[Constants.MAX_MSG_HISTORY];

		private int nextIndex = 0;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Chat);
			chatHistory = FindViewById<TextView> (Resource.Id.chatHistory);
			sendButton = FindViewById<Button> (Resource.Id.sendButton);

			sendButton.Click += (sender, e) => {
				TextView input = FindViewById<TextView> (Resource.Id.input_message);
				WarpClient.GetInstance().SendChat(input.Text);
			};

			WarpClient.GetInstance().AddNotificationListener(this);
		}

		protected override void OnStop ()
		{
			base.OnStop();
			WarpClient.GetInstance().LeaveRoom(Constants.CHAT_ROOM_ID);
		}

		public void onChatReceived (ChatEvent eventObj)
		{
			String sender = eventObj.getSender ();
			String message = eventObj.getMessage ();
			history [nextIndex].sender = sender;
			history [nextIndex].message = message;
			nextIndex++;
			if (nextIndex >= Constants.MAX_MSG_HISTORY) {
				nextIndex = 0;
			}

			String lines="";
			for (int i=0; i<Constants.MAX_MSG_HISTORY; i++) {
				if((history[i].message != null) && (history[i].message.Length > 0)){
					String line = history[i].sender+":"+history[i].message+"\n";
					lines += line;
				}
			}
			RunOnUiThread(() => updateHistory(lines));
		}

		private void updateHistory (String newHistory)
		{
			chatHistory.Text = newHistory;
		}

		public void onRoomCreated (RoomData eventObj)
		{
		}
		
		public void onRoomDestroyed (RoomData eventObj)
		{
		}
		
		public void onUpdatePeersReceived (UpdateEvent eventObj){
		}
		
		public void onUserJoinedLobby (LobbyData eventObj, string username){
		}
		
		public void onUserJoinedRoom (RoomData eventObj, string username)
		{
		}
		
		public void onUserLeftLobby (LobbyData eventObj, string username)
		{
		}
		
		public void onUserLeftRoom (RoomData eventObj, string username){
		}

		public void onUserChangeRoomProperty(RoomData roomData, string sender, Dictionary<string, Object> properties, Dictionary<string, string> lockedPropertiesTable){
		}


		public void onPrivateChatReceived(string sender, string message){
		}


		public void onMoveCompleted(MoveEvent moveEvent){
		}


		public void onUserPaused(string locid, Boolean isLobby, string username){
		}


		public void onUserResumed(string locid, Boolean isLobby, string username){
		}


		public void onGameStarted(string sender, string roomId, string nextTurn){
		}

		public void onGameStopped(string sender, string roomId){
		}

		private struct ChatMessage
		{
			public String sender;
			public String message;
		}
	}
}

