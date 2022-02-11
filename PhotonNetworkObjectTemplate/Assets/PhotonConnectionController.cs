using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine.UI;

public class PhotonConnectionController : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField userNickNameInputField;

    [SerializeField] private Button loginButton;

    [SerializeField] private GameObject loginPanel;

    [SerializeField] private Button joinRoomButton;

    [SerializeField] private GameObject joinRoomPanel;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    private void Start()
    {
        loginButton.onClick.AddListener(onLoginButtonPressed);

        joinRoomButton.onClick.AddListener(OnJoinRoomButtonPressed);

        InitializeConnection();
    }

    private void InitializeConnection()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        loginButton.interactable = true;
    }

    private void onLoginButtonPressed()
    {
        if (string.IsNullOrEmpty(userNickNameInputField.text))
        {
            return;
        }
        loginPanel.SetActive(false);
        joinRoomPanel.SetActive(true);
        PhotonNetwork.NickName = userNickNameInputField.text;
    }

    private void OnJoinRoomButtonPressed()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions roomOps = new RoomOptions { MaxPlayers = 20};

        PhotonNetwork.CreateRoom("Room" + PhotonNetwork.CountOfRooms, roomOps);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined the " + PhotonNetwork.CurrentRoom.Name);

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("GamePlayScene");
        }
    }
}
