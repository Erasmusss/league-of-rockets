using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the object

    private Vector3 targetPosition;
    private bool isMoving = false;
    public bool canMove = true;
    public bool turretExists = false;

    public Rigidbody2D PlayerBody;
    private Vector3 mousePos;
    public Camera MainCam;
    public LogicManageScript LogicManager;
    public GameObject Turret;
    private GameObject turretInstance;

    //cooldowns & abilities
    public float dashCD = 10f;
    public float dashDistance = 20f;
    private float dashTimer = 0f;

    public string boosterType;
    public string heavyGunType;

    // Start is called before the first frame update
    void Start()
    {
        LogicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManageScript>();
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        boosterType = "None";
        heavyGunType = "None";
        turretExists = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!turretExists)
            {
                turretInstance = Instantiate(Turret);
                LogicManager.FindTurretHealthBarManager();
                turretExists = true;
            }
            else
            {
                Destroy(turretInstance);
                turretExists = false;
            }
        }

        if (canMove)
        {
            RotateTowardsMouse();
            MoveTowardsMouseOnRightClick();

            if (Input.GetKeyDown(KeyCode.Space) && dashTimer <= 0 && boosterType == "DashBooster")
            {
                Dash();
            }
        }

        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
            LogicManager.ChangeDashCD(Mathf.RoundToInt(dashTimer));
        }
        //Debug.Log(dashTimer);
    }

    void RotateTowardsMouse()
    {
        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ - 90);
    }

    void MoveTowardsMouseOnRightClick()
    {
        // Check for right mouse button click
        if (Input.GetMouseButton(1) && Vector3.Distance(transform.position, MainCam.ScreenToWorldPoint(Input.mousePosition)) > 5.0f)
        {
            // Convert the mouse position to world space
            targetPosition = MainCam.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0; // Ensure the target position is on the same plane as the object

            isMoving = true; // Set the flag to start moving
        }
        else
        {
            targetPosition = transform.position;
        }

        // Move the object towards the target position
        if (isMoving)
        {
            float step = speed * Time.deltaTime; // Calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Check if the object has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false; // Stop moving
            }
        }
    }

    void Dash()
    {
        Debug.Log("Dash");
        targetPosition = MainCam.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, dashDistance);
        dashTimer = dashCD;
    }

    void PrepForModding()
    {
        //transform.
    }
}
