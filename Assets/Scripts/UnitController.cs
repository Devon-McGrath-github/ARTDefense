using UnityEngine;
using System.Collections;

public class  UnitController : MonoBehaviour {
    public int health = 100;
    //private MeshRenderer meshRenderer;

    private MeshCollider meshCollider;

	// Use this for initialization
	void Start () {
        //meshRenderer = this.GetComponentInChildren<MeshRenderer>();
        meshCollider = this.GetComponent<MeshCollider>();
        
	}
	
    public void ChangeHealth(int change)
    {
        health += change;

    }

    private void CheckHealth()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
        //meshRenderer.enabled = !meshRenderer.enabled;
        CheckHealth();
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            ChangeHealth(-100);
        }
    }
}
