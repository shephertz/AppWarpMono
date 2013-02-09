using System;
using System.Net;
using System.Windows;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client;
using HelloWorld_iPhone;

namespace AppWarp_WP7_TestSDK
{
    public class RoomReqListener : com.shephertz.app42.gaming.multiplayer.client.listener.RoomRequestListener
    {
		private HelloWorld_iPhoneViewController _page;

		public RoomReqListener(HelloWorld_iPhoneViewController page)
        {
            _page = page;
        }

        public void onSubscribeRoomDone(RoomEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                _page.showResult("Yay! Subscribe room :)");
				WarpClient.GetInstance().SendChat("Testing 1..2..3");
            }
        }

        public void onUnSubscribeRoomDone(RoomEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                _page.showResult("Yay! UnSubscribe room :)");
            }
        }

        public void onJoinRoomDone(RoomEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                _page.showResult("Yay! joined room :)");      
				WarpClient.GetInstance().SubscribeRoom(_page.roomId);
            }
        }

        public void onLeaveRoomDone(RoomEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                _page.showResult("Yay! Leave room :)");
            }
        }

        public void onGetLiveRoomInfoDone(LiveRoomInfoEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS && (eventObj.getJoinedUsers() != null))
            {
              _page.showResult("Yay! onGetLiveRoomInfoDone user count is " + eventObj.getJoinedUsers().Length + " " + eventObj.getCustomData());
            }            
        }

        public void onSetCustomRoomDataDone(LiveRoomInfoEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
        _page.showResult("Yay! SetCustomRoomDataDone room :)" + eventObj.getCustomData());
            }
        }

    }
}
