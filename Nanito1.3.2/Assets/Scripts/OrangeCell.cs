using UnityEngine;
using System.Collections;

public class OrangeCell : MonoBehaviour {

	public int damage = 2;
	public bool slow = false;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		
		NanitoControllerScript nanito = GetComponent<NanitoControllerScript> ();
		
		if (collision.gameObject.tag == "bullet") {
			
			Destroy(this.gameObject);
		}
		
	}
}
