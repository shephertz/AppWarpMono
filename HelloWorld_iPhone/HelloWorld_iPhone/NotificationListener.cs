using System;
using System.Net;
using System.Windows;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client;
using HelloWorld_iPhone;

namespace AppWarp_WP7_TestSDK
{
    public class NotificationListener : com.shephertz.app42.gaming.multiplayer.client.listener.NotifyListener
    {
		private HelloWorld_iPhoneViewController _page;

		public NotificationListener(HelloWorld_iPhoneViewController page)
        {
            _page = page;
        }

        public void onRoomCreated(RoomData eventObj)
        {
            _page.showResult("Room Created with name " + eventObj.getName() + " and Id " + eventObj.getId());
        }

        public void onRoomDestroyed(RoomData eventObj)
        {
            _page.showResult("Room Deleted with name " + eventObj.getName() + " and Id " + eventObj.getId());
        }

        public void onUserLeftRoom(RoomData eventObj, String username)
        {
            _page.showResult("User with the name " + eventObj.getName() + " left room of id " + eventObj.getId());
        }

        public void onUserJoinedRoom(RoomData eventObj, String username)
        {
            _page.showResult(username + " joined " + eventObj.getId());
        }

        public void onUserLeftLobby(LobbyData eventObj, String username)
        {
            _page.showResult(username + " left lobby");
        }

        public void onUserJoinedLobby(LobbyData eventObj, String username)
        {
            _page.showResult(username + " joined lobby");
        }

        public void onChatReceived(ChatEvent eventObj)
        {
            _page.showResult("chat from " + eventObj.getSender() + " msg " + eventObj.getMessage() + " id "+eventObj.getLocationId() + eventObj.isLocationLobby());          
        }

        public void onUpdatePeersReceived(UpdateEvent eventObj)
        {
            string j = System.Text.UnicodeEncoding.Unicode.GetString(eventObj.getUpdate(), 0, eventObj.getUpdate().Length);
            _page.showResult("update received " + j );
        }
    }
}
