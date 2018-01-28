using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : Photon.MonoBehaviour {

    public Transform spawnPoint;
    public GameObject playerWeb;
    public Camera lobbyCamera;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("absa");
        StartCoroutine(WaitforSecond());
    }

    private void Update()
    {
        Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
        if (transform.childCount == 0)
        {
            lobbyCamera.enabled = true;
        }
    }
    public virtual void OnJoinedLobby()
    {
        Debug.Log("connect to new");
        PhotonNetwork.JoinOrCreateRoom("a", null, null);
    }


    public virtual void OnJoinedRoom()
    {
        Debug.Log("Create player");
        lobbyCamera.enabled = false;
        var player = (GameObject) PhotonNetwork.Instantiate(playerWeb.name, spawnPoint.position, spawnPoint.rotation, 0);
        player.transform.parent = transform;
        var controller = player.GetComponentInChildren<PlayerController>();
        controller.enabled = true;
        var playerCam = player.GetComponentInChildren<Camera>();
        playerCam.enabled = true;
    }

    private IEnumerator WaitforSecond()
    {
        yield return new WaitForSeconds(5);
        OnJoinedLobby();
    }
}
