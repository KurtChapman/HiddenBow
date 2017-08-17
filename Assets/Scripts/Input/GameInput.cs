using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HB
{
	 public class GameInput
	 {
		  public bool Pressed
		  {
				get
				{
					 return Input.GetMouseButtonDown(0);
				}
		  }
		  public bool Released
		  {
				get
				{
					 return Input.GetMouseButtonUp(0);
				}
		  }
		  public Vector3 Position
		  {
				get
				{
					 return Input.mousePosition;
				}
		  }
		  public Vector3 GetWorldSpacePosition
		  {
				get
				{
					 return Camera.main.ScreenToWorldPoint(Position);
				}
		  }
	 }
}
