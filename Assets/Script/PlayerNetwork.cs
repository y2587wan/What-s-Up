using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour {

    private GameObject playerCamera;
    private List<MonoBehaviour> playerControllers;
    private PhotonView photonView;

	void Start () {
        photonView = transform.parent.GetComponent<PhotonView>();
        Initialize();
	}
	
	// Update is called once per frame
	private void Initialize()
    {
        if (!photonView.isMine)
        {
            playerCamera.SetActive(false);
            foreach (var item in playerControllers)
            {
                item.enabled = false;
            }
        }
	}
}
