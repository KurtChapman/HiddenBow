using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utils
{
	 static public class Utils
	 {
		 public static bool ClickedOnObject(GameObject o, Vector3 clickPointInWorldCoords)
		  {
				var expectedName = o.name;
				RaycastHit2D hit = Physics2D.Raycast(clickPointInWorldCoords, Vector2.zero);
				if (hit.collider != null)
				{
					 if (hit.transform.gameObject.name == expectedName)
					 {
						  return true;
					 }
				}
				return false;
		  }
	 }
}
