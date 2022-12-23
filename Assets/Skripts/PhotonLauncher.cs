using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Skripts
{
    public class PhotonLauncher : MonoBehaviourPunCallbacks
    {
        public static List<string> RoomList = new List<string>();
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject loading;
        [SerializeField] private GameObject roomMenu;
        [SerializeField] private GameObject joinRoom;

        void Start()
        {
            loading.SetActive(true);
            mainMenu.SetActive(false);
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            loading.SetActive(false);
            mainMenu.SetActive(true);
            Debug.Log("Connected to Lobby");
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Connected to the Room");
            loading.SetActive(false);
            roomMenu.SetActive(true);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.LogError("Not connected to the Room. " + message);   
        }
        
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            RoomList.Clear();
            foreach (var el in roomList)
            {
                RoomList.Add(el.Name);
            }
            joinRoom.GetComponent<ListOfRooms>().ChangeRooms();
        }
    }
}