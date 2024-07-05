/*他者が作成したプログラムを自身で変更*/

using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Online : MonoBehaviourPunCallbacks
{
    private int playerCount;

    private void Start()
    {
        PhotonNetwork.LocalPlayer.NickName = "HAMU" + Random.Range(1000, 9999); ;
        PhotonNetwork.ConnectUsingSettings();
        DontDestroyOnLoad(gameObject);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {


        Vector3 position = new Vector3(Random.Range(-20f, 20f), 2, Random.Range(-20f, 20f));
        PhotonNetwork.Instantiate("PlayerNoCame", position, Quaternion.identity);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (PlayerHPScript.Live == 1)
            {


            }
        }
    }
}