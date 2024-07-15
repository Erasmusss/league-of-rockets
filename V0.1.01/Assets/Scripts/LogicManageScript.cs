using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LogicManageScript : MonoBehaviour
{
    public Canvas GameUI;
    public Canvas ModdingUI;
    public Canvas BoosterUI;
    public Canvas HeavyGunsUI;

    public Text DashCDText;

    public Camera MainCam;

    public PlayerController Player;

    
    public DebugTurretScript Turret;
    public TurretHealthBar TurretHealthBarManager;

    public GameObject DashBooster;
    GameObject dashBoosterInstance;
    public GameObject BigGun;
    GameObject bigGunInstance;

    private bool boosterEquipped;
    private bool heavyGunEquipped;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        StartModdingUI();

        DashCDText.enabled = false;
        boosterEquipped = false;
        heavyGunEquipped = false;
    }

    public void FindTurretHealthBarManager()
    {
        Turret = GameObject.FindGameObjectWithTag("Turret").GetComponent<DebugTurretScript>();
        TurretHealthBarManager = GameObject.FindGameObjectWithTag("TurretHealthBar").GetComponent<TurretHealthBar>();
    }
    public void UpdateTurretHealth(float damage)
    {
        Turret.InflictDamage(damage);
    }


    //Handles Dash Cooldown
    //[ContextMenu("ChangeDashCD")]
    public void ChangeDashCD(float number)
    {
        DashCDText.text = "DASH\n" + number.ToString();
        if(number <= 0)
        {
            DashCDText.text = "DASH\nREADY";
        }
    }

    //Handles Ship Modding UI
    //[ContextMenu("disable")]
    public void StartModdingUI()
    {
        ModdingUI.enabled = true;

        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        Player.transform.position = new Vector3(0, 0, 0);
        Player.canMove = false;

        MainCam.orthographicSize = 8;

        GameUI.enabled = false;
        BoosterUI.enabled = false;
        HeavyGunsUI.enabled = false;
    }

    //Handles Modding Start Menu
    public void ReadyButton()
    {
        Player.canMove = true;
        MainCam.orthographicSize = 30;

        GameUI.enabled = true;
        ModdingUI.enabled = false;
    }

    public void BackButton()
    {
        StartModdingUI();
    }


    //Handles Boosters Menu

    public void BoostersButton()
    {
        ModdingUI.enabled = false;
        BoosterUI.enabled = true;
    }
    public void DashBoosterButton()
    {
        if (boosterEquipped)
        {
            Destroy(dashBoosterInstance);
            Player.boosterType = "None";
            DashCDText.enabled = false;
            boosterEquipped = false;
        }
        else
        {
            Player.boosterType = "DashBooster";
            DashCDText.enabled = true;
            boosterEquipped = true;

            dashBoosterInstance = Instantiate(DashBooster, Player.transform);

            // Flip dash booster vertically
            dashBoosterInstance.transform.localScale = new Vector3(
                dashBoosterInstance.transform.localScale.x,
                dashBoosterInstance.transform.localScale.y * -1,
                dashBoosterInstance.transform.localScale.z
            );

            // Offset dash booster by -3
            dashBoosterInstance.transform.localPosition = new Vector3(
                dashBoosterInstance.transform.localPosition.x,
                dashBoosterInstance.transform.localPosition.y - 3,
                dashBoosterInstance.transform.localPosition.z
            );
        }
    }


    //Handles Heavy Guns Menu

    public void HeavyGunsButton()
    {
        ModdingUI.enabled = false;
        HeavyGunsUI.enabled = true;
    }
    public void BigBulletGunButton()
    {
        if (heavyGunEquipped)
        {
            Destroy(bigGunInstance);
            Player.heavyGunType = "None";
            heavyGunEquipped = false;
        }
        else
        {
            Player.heavyGunType = "BigGun";
            DashCDText.enabled = true;
            heavyGunEquipped = true;

            bigGunInstance = Instantiate(BigGun, Player.transform);

            bigGunInstance.transform.localPosition = new Vector3(
                bigGunInstance.transform.localPosition.x - 1.36f,
                bigGunInstance.transform.localPosition.y + 0.4f,
                bigGunInstance.transform.localPosition.z
            );
        }
    }

}
