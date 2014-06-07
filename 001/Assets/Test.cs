using UnityEngine;
using System.Collections;

public class Test : MonoBehavio
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (gameObject.transform.forward);
	}
}
