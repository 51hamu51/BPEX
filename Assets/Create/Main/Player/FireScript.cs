using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class FireScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform firingPoint;
    [SerializeField]
    private Transform firingPoint2;
    [SerializeField]
    private Transform firingPoint3;
    [SerializeField]
    private Transform escudoPoint;
    [SerializeField]
    private Transform hopperPoint;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bulletModel;
    [SerializeField]
    private GameObject meteora;
    [SerializeField]
    private GameObject leadbullet;
    [SerializeField]
    private GameObject hound;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject kogetu;


    private float speed = 1000f;
    private int bulletmax = 40;
    public static int bulletnum = 40;
    public static int reloadMana = 0;
    public static int bulletmode = 1;
    public static int shieldC = 0;
    public static int kogetuC = 0;
    public static int chameleonC = 0;
    /*   private int asteroidReady = 0; */

    private Camera mainCamera;

    private PlayerHPScript playerHPS;

    private PlayerScript PlayerS;

    void Start()
    {

    }


    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if ((((Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.E)) && bulletmode == 1) || Input.GetKeyDown(KeyCode.Q) && bulletmode == 3) && PauseTextScript.Pause == 1)
        {

            bulletmode = 2;
        }
        else if ((((Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.E)) && bulletmode == 2) || Input.GetKeyDown(KeyCode.Q) && bulletmode == 4) && PauseTextScript.Pause == 1)
        {

            bulletmode = 3;
        }
        else if ((((Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.E)) && bulletmode == 3) || Input.GetKeyDown(KeyCode.Q) && bulletmode == 1) && PauseTextScript.Pause == 1)
        {

            bulletmode = 4;
        }
        else if ((((Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.E)) && bulletmode == 4) || Input.GetKeyDown(KeyCode.Q) && bulletmode == 2) && PauseTextScript.Pause == 1)
        {

            bulletmode = 1;
        }

        if (playerHPS == null)
        {
            playerHPS = GameObject.Find("PlayerObserver").GetComponent<PlayerHPScript>();
        }

        if (PlayerS == null)
        {
            PlayerS = playerHPS.playerobj.GetComponent<PlayerScript>();
        }

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }



        if (Input.GetMouseButtonDown(0) && playerHPS.PlayerHP > 0 && bulletnum > 0 && reloadMana == 0 && PauseTextScript.Pause == 1 && WeaponName() == "asteroid")
        {
            /*  アステロイド  */
            StraightBullet("bullet", 1);
        }
        if (Input.GetMouseButtonDown(0) && playerHPS.PlayerHP > 0 && bulletnum > 4 && reloadMana == 0 && PauseTextScript.Pause == 1 && WeaponName() == "meteora")
        {
            /* メテオラ */
            StraightBullet("ReMeteora", 5);
        }
        if (Input.GetMouseButtonDown(0) && playerHPS.PlayerHP > 0 && bulletnum > 4 && reloadMana == 0 && PauseTextScript.Pause == 1 && WeaponName() == "leadbullet")
        {
            /* レッドバレット */
            StraightBullet("leadbullet", 5);
        }
        if (Input.GetMouseButtonDown(0) && playerHPS.PlayerHP > 0 && bulletnum > 2 && reloadMana == 0 && PauseTextScript.Pause == 1 && WeaponName() == "hound")
        {
            /* ハウンド */

            GameObject bullets = PhotonNetwork.Instantiate("hound", firingPoint.position, Quaternion.identity, 0) as GameObject;

            bulletnum -= 3;
        }
        if (Input.GetMouseButtonDown(0) && playerHPS.PlayerHP > 0 && PauseTextScript.Pause == 1 && PlayerScript.stamina > 0 && shieldC == 0 && WeaponName() == "shield")
        {
            /*  シールド */
            shieldC = 1;
            GameObject shields = PhotonNetwork.Instantiate("shield", this.transform.position, Quaternion.identity, 0) as GameObject;

        }
        if (Input.GetMouseButtonDown(0) && playerHPS.PlayerHP > 0 && PauseTextScript.Pause == 1 && PlayerScript.stamina >= 1.5f && shieldC == 0 && WeaponName() == "escudo")
        {
            /*  エスクード */

            GameObject escudos = PhotonNetwork.Instantiate("Escudo", escudoPoint.position, this.transform.rotation, 0) as GameObject;
            PlayerScript.stamina -= 1.5f;

        }
        if (Input.GetMouseButtonDown(0) && playerHPS.PlayerHP > 0 && PauseTextScript.Pause == 1 && PlayerScript.stamina >= 0.7f && PlayerScript.lead == 0 && WeaponName() == "grasshopper")
        {

            /*  グラスホッパー */
            GameObject hoppers = PhotonNetwork.Instantiate("GrassHopper", hopperPoint.position, this.transform.rotation, 0) as GameObject;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += PlayerS.speed * transform.up * Time.deltaTime * 3;

                PlayerS.speed = 300;
                PlayerScript.stamina -= 0.7f;
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position += speed * transform.forward * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position -= speed * transform.forward * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += speed * transform.right * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position -= speed * transform.right * Time.deltaTime;
                }
            }
            else
            {
                transform.position += PlayerS.speed * transform.up * Time.deltaTime * 1;
                PlayerScript.stamina -= 0.7f;
            }

        }

        /*   if (Input.GetMouseButtonDown(0) && playerHPS.PlayerHP > 0 && PauseTextScript.Pause == 1 && PlayerScript.stamina > 0 && chameleonC == 0 && WeaponName() == "chameleon")
          {

              chameleonC = 1;


          }
          else if (Input.GetMouseButtonDown(0) && PauseTextScript.Pause == 1 || PlayerScript.stamina <= 0 || WeaponName() != "chameleon")
          {

              chameleonC = 0;

          } */
        /* if (chameleonC == 1)
        {
            
            GetComponent<Renderer>().material.color = new Color32(28, 86, 236, 60);
            this.tag = "Chameleon";
            gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
            PlayerScript.stamina -= Time.deltaTime * 1.3f;
            if (PlayerScript.stamina <= 0)
            {
                PlayerScript.stamina = 0;
                chameleonC = 0;
            }
        }
        else if (PlayerScript.lead == 0 && PlayerScript.damage == 0)
        {
            
            GetComponent<Renderer>().material.color = new Color32(28, 86, 236, 255);
            this.tag = "Me";
            gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
        }
        else if (PlayerScript.lead != 0)
        {
            GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 255);
            this.tag = "Me";
            gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 255);
            this.tag = "Me";
            gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
        } */


        if (PauseTextScript.Pause == 1 && WeaponName() == "free")
        {
            /* フリー */
            bulletmode += 1;
            if (bulletmode == 5)
            {
                bulletmode = 1;
            }
        }
        if (PauseTextScript.Pause == 1 && WeaponName() == "free2")
        {
            /* フリー2 */
            bulletmode += 1;
            if (bulletmode == 5)
            {
                bulletmode = 1;
            }
        }
        if (PauseTextScript.Pause == 1 && WeaponName() == "free3")
        {
            /* フリー3 */
            bulletmode += 1;
            if (bulletmode == 5)
            {
                bulletmode = 1;
            }
        }
        if (playerHPS.PlayerHP > 0 && PauseTextScript.Pause == 1 && WeaponName() == "kogetu" && kogetuC == 0)
        {
            /*  弧月 */

            GameObject kogetus = PhotonNetwork.Instantiate("kogetu", Vector3.zero, Quaternion.identity, 0) as GameObject;
            kogetus.transform.position = this.transform.position;
            kogetuC = 1;
        }


        if (Input.GetMouseButtonDown(1) && PauseTextScript.Pause == 1)
        {
            /*リロード*/
            reloadMana = 1;
            Invoke("Reload", 1f);

        }

    }

    void Reload()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        bulletnum = bulletmax;
        reloadMana = 0;
    }

    /// <summary>
    /// まっすぐ飛ぶ弾の共通処理
    /// </summary>
    /// <param name="bulletName">Asset上の弾の名前</param>
    private void StraightBullet(string bulletName, int amount)
    {
        // 画面中心からRayを飛ばす
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        // ヒットした場所 or まっすぐ1000m先
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(1000f);
        }

        // 発射方向を計算
        Vector3 shootDir = (targetPoint - firingPoint.position).normalized;

        //発射
        GameObject bulletObj = PhotonNetwork.Instantiate(bulletName, firingPoint.position, Quaternion.LookRotation(shootDir), 0);
        bulletObj.GetComponent<Rigidbody>().AddForce(shootDir * speed);


        bulletnum -= amount;

    }

    /// <summary>
    /// 現在選択されている武器の名前を返す
    /// </summary>
    /// <returns></returns>
    public string WeaponName()
    {
        return SettingTextScript.Bul[bulletmode - 1];
    }




}


/*  
****  3方向弾  ****
  GameObject bullets = Instantiate(bullet) as GameObject;
   GameObject bullet2 = Instantiate(bullet) as GameObject;
   GameObject bullet3 = Instantiate(bullet) as GameObject;
   Vector3 force;
   Vector3 force2;
   Vector3 force3;
   force = this.gameObject.transform.forward * speed;
   force2 = this.gameObject.transform.right * speed;
   force3 = this.gameObject.transform.right * -speed;
   bullets.GetComponent<Rigidbody>().AddForce(force);
   bullet2.GetComponent<Rigidbody>().AddForce(force2);
   bullet3.GetComponent<Rigidbody>().AddForce(force3);
   bullets.transform.position = firingPoint.position;
   bullet2.transform.position = firingPoint2.position;
   bullet3.transform.position = firingPoint3.position;
   bulletnum -= 3; */