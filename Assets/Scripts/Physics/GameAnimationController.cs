using UnityEngine;
using System.Collections;

public class GameAnimationController : MonoBehaviour {

	public float animationTimer = 0.6f;
	enum DirectionFacing
	{
		Left,
		Right
	};
	DirectionFacing facing;

	// Use this for initialization
	void Start () {
		facing = DirectionFacing.Right;
	}
	
	// Update is called once per frame
	void Update ()
	{
		MovementPhysicsController obj = GetComponent<MovementPhysicsController> ();
		if (obj != null) 
		{
			Vector2 currentPos = transform.position;
			Vector2 direction = obj.TargetPos - currentPos;
			direction.Normalize();

			if(direction.x == 0)
				GetComponent<Animator>().speed = 0;
			else{
				GetComponent<Animator>().speed = animationTimer;
				DirectionFacing newFacing;
				if(direction.x > 0)
					newFacing = DirectionFacing.Right;
				else if(direction.x < 0)
					newFacing = DirectionFacing.Left;
				else
					newFacing = facing;

				if(facing != newFacing)
				{
					transform.Rotate(0, 180, 0);
					facing = newFacing;
				}
			}

		}
	}
}
