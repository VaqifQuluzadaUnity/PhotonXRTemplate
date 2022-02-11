using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerGamePlayController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        if (playerPrefab == null)
        {
            Debug.Log("Player prefab is empty");
        }
        else
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[PhotonNetwork.CurrentRoom.PlayerCount-1].position,Quaternion.identity);
        }
    }
}
