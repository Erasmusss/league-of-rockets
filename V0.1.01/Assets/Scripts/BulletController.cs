using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody2D BulletBody;
    public LogicManageScript LogicManager;

    public float maxRange = 100f;
    public float speed = 50f;
    public float damage = 25f;

    private Vector3 targetPos;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        LogicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManageScript>();

        startPos = transform.position;
        
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0; // Ensure the target position is on the same plane as the bullet

        Vector2 direction = (targetPos - transform.position).normalized;

        BulletBody.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation of the bullet to face the target position
        Vector3 rotation = targetPos - transform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ - 90);

        if (Vector3.Distance(transform.position, startPos) > 200f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered");
        if (collision.CompareTag("Turret"))
        {
            Debug.Log("entered turret");
            LogicManager.UpdateTurretHealth(damage);
            Destroy(gameObject);
        }
        
    }
}
