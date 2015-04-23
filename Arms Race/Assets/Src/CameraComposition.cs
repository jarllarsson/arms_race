using UnityEngine;
using System.Collections;

public class CameraComposition : MonoBehaviour 
{
    public Camera[] m_MainCameras;
    public CamFollow[] m_MainCamerasFollowScripts;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetRacerCars(GameObject[] m_cars)
	{
		for (int i=0;i<m_cars.Length;i++)
		{
			GameObject car=m_cars[i];
			if (i<m_MainCameras.Length && i<m_MainCamerasFollowScripts.Length)
			{
				Transform lookObj=car.transform.FindChild("CamLook");
				Transform followObj=car.transform.FindChild("CamFollow");
				if (lookObj && followObj)
				{
					m_MainCamerasFollowScripts[i].m_goal=followObj;
					m_MainCamerasFollowScripts[i].m_lookAt=lookObj;
				}
				CarController controller = car.GetComponent<CarController>();
				ShakerFx shaker = m_MainCameras[i].gameObject.GetComponentInChildren<ShakerFx>();
				if (controller && shaker)
				{
					controller.m_hitInfo.m_camShake = shaker;
				}
			}
		}
	}
}
