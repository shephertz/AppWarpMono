
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client;

using System.Collections.Generic;

namespace HelloWorld_iPhone
{
	public partial class ChatController : UIViewController, NotifyListener
	{
		private ChatMessage[] history = new ChatMessage[Constants.MAX_MSG_HISTORY];
		
		private int nextIndex = 0;

		public ChatController () : base ("ChatController", null)
		{
			WarpClient.GetInstance().AddNotificationListener(this);
		}

		partial void onSendClicked (NSObject sender)
		{
			WarpClient.GetInstance().SendChat(this.inputTextField.Text);
			inputTextField.ResignFirstResponder();
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
			historyLabel.Lines = 0;
			this.View.BackgroundColor= UIColor.FromPatternImage(UIImage.FromFile("game_background.png"));
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
					String line = "  "+history[i].sender+":"+history[i].message+"\n";
					lines += line;
				}
			}
			InvokeOnMainThread (delegate { 
				historyLabel.Text = lines;
			});
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

		public void onGameStarted(string a, string b,string c){}

		public void onGameStopped(string a, string b){}

		public void onUserPaused(string a, bool b, string c){}

		public void onUserResumed(string a, bool b, string c){}

		public void onPrivateChatReceived(string a, string b){}

		public void onMoveCompleted(MoveEvent a){}

		public void onUserChangeRoomProperty(RoomData a, string b, Dictionary<string, object> c, Dictionary<string, string> d)
		{
		}

		private struct ChatMessage
		{
			public String sender;
			public String message;
		}

	}
}

