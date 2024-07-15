using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform PlayerTransform;
    public PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerScript.canMove)
        {
            Debug.Log("Spawn Bullet");

            GameObject bullet = Instantiate(BulletPrefab, PlayerTransform.position, PlayerTransform.rotation);
            //bullet.transform.parent = transform;
        }
    }
}
