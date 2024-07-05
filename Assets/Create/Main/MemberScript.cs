/*他者が作成したプログラムを自身で変更*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class MemberScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI MembersText;
    public static int[] Point = { 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999, 9999 };
    int poi;

    void Start()
    {
        UpdateMemberList();
    }


    void Update()
    {


        UpdateMemberList();
    }

    public void UpdateMemberList()
    {
        MembersText.text = "Member List\n";
        foreach (var p in PhotonNetwork.PlayerList)
        {
            photonView.RPC(nameof(RpcSendPoint), RpcTarget.All, Point[p.ActorNumber], p.NickName, p.ActorNumber);
        }

    }
    [PunRPC]
    private void RpcSendPoint(int point, string name, int num)
    {
        if (point != 9999)
        {
            Point[num] = point;

            MembersText.text += string.Format("{0} : {1}\n", name, Point[num]);
        }
        else
        {


            MembersText.text += string.Format("{0} : {1}\n", name, Point[num]);

        }
    }
}
