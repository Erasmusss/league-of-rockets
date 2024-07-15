using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretHealthBar : MonoBehaviour
{
    public DebugTurretScript Turret;
    [SerializeField] private Slider healthBar;

    public void Start()
    {
        healthBar.maxValue = Turret.maxHealth;
        UpdateHealthBar(Turret.health);
        //Turret = GameObject.FindGameObjectWithTag("Turret").GetComponent<DebugTurretScript>();
    }
    public void UpdateHealthBar(float newHealth)
    {
        healthBar.value = Turret.health;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
