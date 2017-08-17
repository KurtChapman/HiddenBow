using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Player
{
	 class Arrow : MonoBehaviour
	 {
		  public int Speed;
		  private Vector3 direction;

		  void Update()
		  {
				MoveObject();
		  }

		  public void OnBecameInvisible()
		  {
				Debug.Log("Deleting Arrow");
				Destroy(gameObject);
		  }

		  void MoveObject()
		  {
				var velocity = direction * Speed;
				velocity *= Time.deltaTime;
				transform.position += velocity;
		  }

		  public void BeginFire(Vector2 direction)
		  {
				this.direction = direction;
		  }
	 }
}
