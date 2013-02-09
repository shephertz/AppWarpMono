using System;
using System.Net;
using System.Windows;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client;
using HelloWorld_iPhone;

namespace AppWarp_WP7_TestSDK
{
    public class LobbyReqListen : com.shephertz.app42.gaming.multiplayer.client.listener.LobbyRequestListener
    {
		private HelloWorld_iPhoneViewController _page;

		public LobbyReqListen(HelloWorld_iPhoneViewController page)
        {
            _page = page;
        }

        public void onJoinLobbyDone(LobbyEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                _page.showResult("Yay! joined Lobby :)");
				WarpClient.GetInstance().SubscribeLobby();
            }
           
        }
        public void onLeaveLobbyDone(LobbyEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                _page.showResult("Yay! Leave  Lobby :)");
            }
        }
        public void onSubscribeLobbyDone(LobbyEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                _page.showResult("Yay! Subscribe Lobby :)");   
				WarpClient.GetInstance().SendChat("Testing 1..2..3");
            }
        }
        public void onUnSubscribeLobbyDone(LobbyEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                _page.showResult("Yay! Unsubscribe Lobby done :)");
            }
        }

        public void onGetLiveLobbyInfoDone(LiveRoomInfoEvent eventObj)
        {
            if (eventObj.getJoinedUsers() == null)
            {
                return;
            }
            _page.showResult("Yay! Got Live Lobby Info user count "+ eventObj.getJoinedUsers().Length);

            String[] users = eventObj.getJoinedUsers();
            if (users != null && users.Length > 0)
            {
                for (int i = 0; i < users.Length; i++ )
                    _page.showResult(users[i]);
            }
        }
    }
}
