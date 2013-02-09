using System;
using System.Net;
using System.Windows;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client;
using HelloWorld_iPhone;

namespace AppWarp_WP7_TestSDK
{
    public class ZoneReqListener : com.shephertz.app42.gaming.multiplayer.client.listener.ZoneRequestListener
    {
		private HelloWorld_iPhoneViewController _page;

		public ZoneReqListener(HelloWorld_iPhoneViewController page)
        {
            _page = page;
        }     

        public void onDeleteRoomDone(RoomEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                _page.showResult("Room Deleted with name " + eventObj.getData().getName() + " and Id " + eventObj.getData().getId());
            }
        }

        public void onGetAllRoomsDone(AllRoomsEvent eventObj)
        {
            for (int i = 0; i < eventObj.getRoomIds().Length; i++)
            {
            _page.showResult("rooms available are " + eventObj.getRoomIds()[i]);
                }
        }

        public void onCreateRoomDone(RoomEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                _page.showResult("Room Created with name " + eventObj.getData().getName() + " and Id " + eventObj.getData().getId());
            }
        }

        public void onGetOnlineUsersDone(AllUsersEvent eventObj)
        {
            for (int i = 0; i < eventObj.getUserNames().Length; i++)
            {
                _page.showResult("Online User is: " + eventObj.getUserNames()[i]);
            }
        }

        public void onGetLiveUserInfoDone(LiveUserInfoEvent eventObj)
        {
            _page.showResult(" User " + eventObj.getName() + " info is " + eventObj.getCustomData());
        }

        public void onSetCustomUserDataDone(LiveUserInfoEvent eventObj)
        {
            _page.showResult(" User " + eventObj.getName() + " info is " + eventObj.getCustomData());
        }
    }
}
