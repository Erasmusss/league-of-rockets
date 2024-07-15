using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTurretScript : MonoBehaviour
{
    public PlayerController playerScript;
    public LogicManageScript LogicManager;
    public Camera MainCam;
    public Rigidbody2D TurretBody;
    public TurretHealthBar TurretHealthBarManager;

    public float maxHealth = 1000f;
    public float health = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        health = 1000f;
        maxHealth = 1000f;

        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        LogicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManageScript>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        TurretHealthBarManager = GameObject.FindGameObjectWithTag("TurretHealthBar").GetComponent<TurretHealthBar>();

        TurretHealthBarManager.UpdateHealthBar(health);

        Vector3 mousePosition = MainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 
        transform.position = mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InflictDamage(float damage)
    {
        Debug.Log(damage);
        health -= damage;
        TurretHealthBarManager.UpdateHealthBar(health);
    }
}
