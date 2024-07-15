using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGun : MonoBehaviour
{
    public GameObject BulletPrefab;
    //public Transform PlayerTransform;
    public PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && playerScript.canMove)
        {
            Debug.Log("Spawn Bullet");

            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            //bullet.transform.parent = transform;
        }
    }
}
