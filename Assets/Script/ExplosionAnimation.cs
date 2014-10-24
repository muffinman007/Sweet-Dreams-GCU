using UnityEngine;
using System.Collections;

public class ExplosionAnimation : MonoBehaviour{

	public Sprite[] sprites;
	public float fps;
	int framesPerAnimation = 15;			// number of frames per animation sequence

	private SpriteRenderer spriteRenderer;
		
	// Use this for initialization
	void Start (){
		spriteRenderer = renderer as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update (){
			int index = (int)(Time.timeSinceLevelLoad * fps);
			index = index % framesPerAnimation;
			spriteRenderer.sprite = sprites [index];
			
			//if(index >= 15)
				//Destroy(this.gameObject);
	}
}

