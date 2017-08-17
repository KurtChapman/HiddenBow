using UnityEngine;
using System.Collections;

public class MovementPhysicsController : MonoBehaviour {

	public float movementSpeed;

	int targetReachedOffset = 1;
	protected Vector2 targetPos;
	public Vector2 TargetPos {
		get {
			return targetPos;
		}
		set {
			targetPos = value;
		}
	}

	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		  MoveObject();
	}

	 protected void MoveObject()
	 {
		  Vector2 currentPos = transform.position;

		  if (Vector2.Distance(targetPos, currentPos) < targetReachedOffset)
				targetPos = currentPos;

		  if (targetPos != currentPos)
		  {
				Vector2 direction = targetPos - currentPos;
				direction.Normalize();

				Vector2 velocity = direction * movementSpeed;
				transform.position += (Vector3)(velocity * Time.deltaTime);
		  }
	 }
}
