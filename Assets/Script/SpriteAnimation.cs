using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour{
	public Sprite[] sprites;
	public float fps;
	public int framesPerAnimation;			// number of frames per animation sequence

	public static bool isStandingStill = false;

	// the sprite current travling direction
	public enum travelDirection{ RIGHT_UP, LEFT_UP, RIGHT_DOWN, LEFT_DOWN };
	public static travelDirection currentTravelDirection;  

	// enum based on how unity split the spritesheet
	// to get the correct movement sprite, unity split spritesheet into a single dimension array
	public enum offset{ LEFT_DOWN, RIGHT_DOWN, LEFT_UP, RIGHT_UP };
	public static offset frameOffset;

	private SpriteRenderer spriteRenderer;


	// Use this for initialization
	void Start (){
		spriteRenderer = renderer as SpriteRenderer;
	}

	// Update is called once per frame
	void Update (){
		if (!isStandingStill) {
			int index = (int)(Time.timeSinceLevelLoad * fps);
			index = index % framesPerAnimation;
			spriteRenderer.sprite = sprites [index + ((int)frameOffset * framesPerAnimation)];
		}
		else{
			if(currentTravelDirection == travelDirection.LEFT_DOWN)
				spriteRenderer.sprite = sprites[0];
			else if(currentTravelDirection == travelDirection.RIGHT_DOWN)
				spriteRenderer.sprite = sprites[4];
			else if(currentTravelDirection == travelDirection.LEFT_UP)
				spriteRenderer.sprite = sprites[8];
			else if(currentTravelDirection == travelDirection.RIGHT_UP)
				spriteRenderer.sprite = sprites[12];
		}
	}
}

