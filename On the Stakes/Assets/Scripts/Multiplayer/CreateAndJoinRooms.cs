using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    
    [SerializeField]
    private GameObject createInput;

    [SerializeField]
    private Transform content;
    [SerializeField]
    private RoomListing roomListing;

    private string createServerText;

    void Start(){
        createServerText = createInput.GetComponent<TMP_InputField>().text;
    }

    public void CreateRoom(){
        PhotonNetwork.CreateRoom(createServerText);
    }

    public void JoinRoom(TMP_Text _name){
        PhotonNetwork.JoinRoom(_name.text);
    }

    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("GameLobby");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        foreach(RoomInfo info in roomList){
            RoomListing listing = Instantiate(roomListing, content);
            if(listing != null)
                listing.SetRoomInfo(info);
        }
    }

}
