using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private string versionName = "0.1";

    [SerializeField]
    private GameObject userNameMenu;

    [SerializeField]
    private GameObject connectPanel;

    [SerializeField]
    private GameObject singleOrMultiplayer;

    [SerializeField]
    private InputField userNameInput;

    [SerializeField]
    private InputField createGameInput;

    [SerializeField]
    private InputField joinGameInput;

    [SerializeField]
    private GameObject startButton;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }
    // Start is called before the first frame update
    void Start()
    {
        //userNameMenu.SetActive(true);
        singleOrMultiplayer.SetActive(true);

    }

    public void SinglePlayer()
    {
        Debug.Log("Single");
    }
    public void MultiPlayer()
    {
        singleOrMultiplayer.SetActive(false);
        userNameMenu.SetActive(true);
    }

    public void ChangeUserNameInput()
    {
        if(userNameInput.text.Length >= 3)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }
    public void SetUserName()
    {
        userNameMenu.SetActive(false);
        PhotonNetwork.NickName = userNameInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(createGameInput.text, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(joinGameInput.text, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Boids_MP");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
