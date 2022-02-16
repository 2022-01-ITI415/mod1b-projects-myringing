using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Slingshot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    static public Slingshot S;
    public GameObject prefabProjectile;
    public float velocityMult = 4f;
    public bool _____________________________;
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public Mouse mouse = Mouse.current;

    void Awake()
    {
        S = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }

    private void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        aimingMode = true;
        projectile = Instantiate(prefabProjectile) as GameObject;
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!aimingMode) return;
        Vector2 mousePos2D = mouse.position.ReadValue();
        Vector3 mousePose3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        mousePose3D.z = -Camera.main.transform.position.z;
        Vector3 mouseDelta = mousePose3D - launchPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;
            FollowCam.S.poi = projectile;
            projectile = null;
            MissionDemolition.ShotFired();
        }
    }
}
