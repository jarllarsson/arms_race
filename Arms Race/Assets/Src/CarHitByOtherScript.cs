using UnityEngine;
using System.Collections;

public class CarHitByOtherScript : MonoBehaviour 
{
    public Rigidbody m_rigidbody;
    public GameObject m_hitSparks;
    public AudioSource m_soundSource;
    public AudioClip[] m_hitSounds;
    public ShakerFx m_camShake;
    private float m_timer=0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_timer > 0.0f)
        {
            m_timer -= Time.deltaTime;
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        OnColl(coll);
    }

    void OnTriggerStay(Collider coll)
    {
        OnColl(coll);
    }

    public bool isHit()
    {
        return m_timer > 0.0f;
    }

    void OnColl(Collider coll)
    {
        //Debug.Log(coll.gameObject.tag);
        if (m_timer<=0.0f)
        {
            if (coll.gameObject.tag == "carHit" && coll.transform.parent.name != gameObject.name)
            {

                CarAttack atkScript = coll.transform.parent.GetComponent<CarAttack>();
                if (atkScript)
                    atkScript.HitSuccess();

                //             if (velocity >= m_velocityOnBallToKillMe)
                //             {
                Vector3 pos = coll.transform.position;
                Vector3 dir = (transform.position-pos).normalized;
                m_rigidbody.AddForceAtPosition((dir.normalized+Vector3.up*0.6f)* 20000.0f, pos);
                m_rigidbody.AddTorque(new Vector3(0.0f, (float)(Random.Range(0, 1)*2 - 1) * 12000000.0f, 0.0f));
                if (m_hitSparks) Instantiate(m_hitSparks, new Vector3(pos.x, pos.y, transform.position.z), Quaternion.identity);
                if (m_soundSource && !m_soundSource.isPlaying) m_soundSource.PlayOneShot(m_hitSounds[Random.Range(0, m_hitSounds.Length)]);
                if (m_camShake) m_camShake.Activate(0.5f, dir * 10.0f, new Vector2(10.0f, 10.0f));
                //}
                m_timer = 1.0f;
            }
        }
    }
}
