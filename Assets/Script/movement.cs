using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	int walkSpeed = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.up * walkSpeed * Time.deltaTime);
			transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.down * walkSpeed * Time.deltaTime);
			transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
			transform.Translate(Vector3.up * walkSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
			transform.Translate(Vector3.down * walkSpeed * Time.deltaTime);
		}
	}
}
