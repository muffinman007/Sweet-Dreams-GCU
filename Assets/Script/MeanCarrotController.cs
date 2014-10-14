﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeanCarrotController : MonoBehaviour{
	public float minimumSecond = 1.0f;
	public float maximumSecond = 2.0f;

	// allow the ai to travel in the same direction at most 2 times in a row
	int travelSameDirLimitor = 2;
	byte[] travelLimitorArray = new byte[]{0, 0, 0, 0, 0};

	public float turnSpeed;
	public float moveSpeed;
	private Vector3 moveDirection;

	float travelDirectionTimer;
	float travelTime = 0.0f;

	// Use this for initialization
	void Start () {
		moveDirection = Vector3.right + Vector3.down;
		SpriteAnimation.currentTravelDirection = SpriteAnimation.travelDirection.RIGHT_DOWN;
		SpriteAnimation.frameOffset = SpriteAnimation.offset.RIGHT_DOWN;
		Random.seed = System.DateTime.Now.Millisecond;
		travelDirectionTimer = Random.Range(minimumSecond, maximumSecond);
	}

	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;

		/* // going to use this to code projectiles that will come out of this enemy and flies toward the main character
		if (Input.GetButton ("Fire1")) {
			Vector3 moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0;
			moveDirection.Normalize();
		}
		*/

		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);

		if( (travelTime += Time.deltaTime) >= travelDirectionTimer ){
			SpriteAnimation.isStandingStill = false;
			int whichDirection = (int)Random.Range(0, 4);

			if( (whichDirection != 4) && ((++travelLimitorArray[whichDirection]) == travelSameDirLimitor) ){
				int anotherDirection;
				do{
					anotherDirection = (int)Random.Range(0, 4);
				}while(anotherDirection == whichDirection);

				whichDirection = anotherDirection;
				for(int i = 0; i < travelLimitorArray.Length; ++i){
					travelLimitorArray[i] = 0;
				}
				++travelLimitorArray[whichDirection];
			}

			for(int i = 0; i < travelLimitorArray.Length; ++i){
				if(i == whichDirection)
					continue;
				travelLimitorArray[i] = 0;
			}

			if(whichDirection == (int)SpriteAnimation.travelDirection.RIGHT_UP){
				if(!(SpriteAnimation.currentTravelDirection == SpriteAnimation.travelDirection.RIGHT_UP)){
					moveDirection = Vector3.right + Vector3.up;
					SpriteAnimation.currentTravelDirection = SpriteAnimation.travelDirection.RIGHT_UP;
					SpriteAnimation.frameOffset = SpriteAnimation.offset.RIGHT_UP;
				}
			}
			else if(whichDirection == (int)SpriteAnimation.travelDirection.LEFT_UP){
				if(!(SpriteAnimation.currentTravelDirection == SpriteAnimation.travelDirection.LEFT_UP)){
					moveDirection = Vector3.left + Vector3.up;
					SpriteAnimation.currentTravelDirection = SpriteAnimation.travelDirection.LEFT_UP;
					SpriteAnimation.frameOffset = SpriteAnimation.offset.LEFT_UP;
				}
			}
			else if(whichDirection == (int)SpriteAnimation.travelDirection.RIGHT_DOWN){
				if(!(SpriteAnimation.currentTravelDirection == SpriteAnimation.travelDirection.RIGHT_DOWN)){
					moveDirection = Vector3.right + Vector3.down;
					SpriteAnimation.currentTravelDirection = SpriteAnimation.travelDirection.RIGHT_DOWN;
					SpriteAnimation.frameOffset = SpriteAnimation.offset.RIGHT_DOWN;
				}
			}
			else if(whichDirection == (int)SpriteAnimation.travelDirection.LEFT_DOWN){
				if(!(SpriteAnimation.currentTravelDirection == SpriteAnimation.travelDirection.LEFT_DOWN)){
					moveDirection = Vector3.left + Vector3.down;
					SpriteAnimation.currentTravelDirection = SpriteAnimation.travelDirection.LEFT_DOWN;
					SpriteAnimation.frameOffset = SpriteAnimation.offset.LEFT_DOWN;
				}
			}
			else{ // standstill
				SpriteAnimation.isStandingStill = true;
			}

			travelTime = 0.0f;
			travelDirectionTimer = Random.Range(minimumSecond, maximumSecond);
		}
	
		//float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime);
	}
}
