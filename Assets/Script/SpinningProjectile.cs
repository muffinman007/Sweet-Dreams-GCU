using UnityEngine;
using UnityEditor;
using System.Collections;


public class SpinningProjectile : MonoBehaviour {

	public float turnSpeed;
	public float moveSpeed;
	private Vector3 moveDirection;	

	private Vector3 mainCharPosition;		// position of the main character at time of launch

	// Use this for initialization
	void Start(){
		mainCharPosition = GameObject.Find ("boy").transform.position;
	}	
	
	// Update is called once per frame
	void Update (){
		Vector3 currentPosition = transform.position;	

		// move toward the coordinate recorded in mainCharPosition
		//Vector3 moveToward = GameObject.Find("boy").transform.position;
		moveDirection = mainCharPosition - currentPosition;
		moveDirection.z = 0;
		moveDirection.Normalize();

		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);	

		//float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime);

		if(AppoximateVectorEquality(mainCharPosition, transform.position)){
			Object explosion = AssetDatabase.LoadAssetAtPath("Assets/prefab/SmallExplosion.prefab", typeof(GameObject));
			Instantiate(explosion, transform.position, Quaternion.identity);
			DestroyImmediate(gameObject);
		}
	}	

	bool AppoximateVectorEquality(Vector3 v1, Vector3 v2){
		return (Mathf.Abs(v1.x - v2.x) <= 0.1) && (Mathf.Abs(v1.y - v2.y) <= 0.1);
	}
}
