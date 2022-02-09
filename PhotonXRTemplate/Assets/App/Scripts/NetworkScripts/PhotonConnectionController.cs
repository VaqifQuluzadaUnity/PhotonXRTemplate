using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// We extend this class from MonoBehaviourPunCallbacks so we can call onConnectedToMaster,onJoinedRoom
/// and other Photon callbacks.
/// </summary>
public class PhotonConnectionController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject errorInfoPanel;

    [SerializeField] private GameObject loginPanel;

    private PhotonErrorHandler errorHandler;
}
