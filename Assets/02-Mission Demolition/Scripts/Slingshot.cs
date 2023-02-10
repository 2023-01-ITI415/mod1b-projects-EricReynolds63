using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
	static private Slingshot S;
	public enum Ammo { cannonball, tracer }

	[Header("Inscribed")]
    public GameObject projectilePrefab;
	public GameObject tracerPrefab;
	public float velocityMult = 10f;
    public GameObject projLinePrefab;

    [Header("Dynamic")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
	public Ammo type = Ammo.cannonball;

	static public void CHANGE_AMMO( Ammo changeTo) {
			S.type = changeTo;
	}

	static public void CHANGE_AMMO()
	{
		if (S.type == Ammo.cannonball){
			S.type = Ammo.tracer;
		} else {
			S.type = Ammo.cannonball;
		}
	}

	void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }

    void OnMouseDown()
    {
        aimingMode = true;
		if (type == Ammo.cannonball) {
			projectile = Instantiate(projectilePrefab) as GameObject;
		} else {
			projectile = Instantiate(tracerPrefab) as GameObject;
			projectile.GetComponent<Projectile>().tracer = true;
		}
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

	void Start()
	{
		S = this;
	}

	void Update()
    {
        if (!aimingMode) { return; }

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude) {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0)) {
            aimingMode = false;
            Rigidbody projRB = projectile.GetComponent<Rigidbody>();
            projRB.isKinematic = false;
            projRB.collisionDetectionMode = CollisionDetectionMode.Continuous;
            projRB.velocity = -mouseDelta * velocityMult;
			FollowCam.SWITCH_VIEW(FollowCam.eView.slingshot);
			FollowCam.POI = projectile;
            Instantiate<GameObject>(projLinePrefab, projectile.transform);
            projectile = null;
			if (type == Ammo.cannonball) {
				MissionDemolition.SHOTS_FIRED();
			}
        }


    }

}
