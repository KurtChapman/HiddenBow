using Assets.Scripts.Utils;
using HB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Player
{
	 class PlayerMovementController : MovementPhysicsController
	 {
		  GameInput mouseInput;
		  void Start()
		  {
				targetPos = transform.position;
				mouseInput = new GameInput();
		  }

		  void Update()
		  {
				if(mouseInput.Pressed)
				{
					 if(!Utils.ClickedOnObject(gameObject, mouseInput.GetWorldSpacePosition))
					 {
						  targetPos = mouseInput.GetWorldSpacePosition;
					 }
				}
				MoveObject();
		  }
	 }
}
