using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject gameCanvas;
    public GameObject sceneCamera;
    //public GameObject flockBehavior;
    public GameObject disconnectUI;
    private bool off = false;

    public GameObject playerFeed;
    public GameObject feedGrid;

    private void Awake()
    {
        gameCanvas.SetActive(true);
    }

    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f, 1f);

        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(this.transform.position.x * randomValue, this.transform.position.y, this.transform.position.z), Quaternion.identity, 0);
        gameCanvas.SetActive(false);
        sceneCamera.SetActive(false);
        //flockBehavior.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (off && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(false);
            off = false;
        }
        else if (!off && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(true);
            off = true;
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("MainMenu");
    }

    private void OnPhotonPlayerConnected(Photon.Realtime.Player player)
    {
        GameObject obj = Instantiate(playerFeed, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.SetParent(feedGrid.transform, false);
        obj.GetComponent<Text>().text = player.NickName + "joined the game";
        obj.GetComponent<Text>().color = Color.green;

    }

    private void OnPhotonPlayerDisconnected(Photon.Realtime.Player player)
    {
        GameObject obj = Instantiate(playerFeed, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.SetParent(feedGrid.transform, false);
        obj.GetComponent<Text>().text = player.NickName + "left the game";
        obj.GetComponent<Text>().color = Color.red;

    }
}
