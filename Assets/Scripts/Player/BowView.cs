using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Player
{
	 public class BowView
	 {
		  float lineWidth = 0.2f;
		  float maxDrawStrength = 1.2f;
		  Transform parentTransform;
		  Material lineMat;

		  public BowView(Transform parent)
		  {
				parentTransform = parent;
				lineMat = Resources.Load("Material/red.png", typeof(Material)) as Material;

		  }

		  public void ShowPowerIndicator(Vector3 mousePos)
		  {
				DrawMesh(mousePos);
		  }

		  public void UpdateWithMousePos(Vector3 mousePos)
		  {
				DrawMesh(mousePos);
		  }

		  void DrawMesh(Vector3 mousePos)
		  {
				var lineMesh = GenerateLineMesh(parentTransform.position, mousePos);
				var meshRotation = GetRotationToPlayer(mousePos);
				Graphics.DrawMesh(lineMesh, parentTransform.position, meshRotation, lineMat, 0);
		  }

		  private Quaternion GetRotationToPlayer(Vector3 mousePos)
		  {
				var pos = Camera.main.WorldToScreenPoint(parentTransform.position);
				var dir = mousePos - pos;
				var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
				Quaternion meshRotation = Quaternion.AngleAxis(angle, Vector3.forward);
				return meshRotation;
		  }

		  private Mesh GenerateLineMesh(Vector3 playerPosition, Vector3 mousePosition)
		  {
				Mesh lineMesh = new Mesh();

				var mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
				var distance = Vector3.Distance(mouseWorldPos, playerPosition) - 10;
				distance = Mathf.Clamp(distance, 0, maxDrawStrength);
				Vector3[] vertices = new Vector3[4];

				vertices[0] = new Vector3(0, 0, 0);
				vertices[1] = new Vector3(lineWidth, 0, 0);
				vertices[2] = new Vector3(0, distance, 0);
				vertices[3] = new Vector3(lineWidth, distance, 0);

				lineMesh.vertices = vertices;

				var tri = new int[6];

				//  Lower left triangle.
				tri[0] = 0;
				tri[1] = 2;
				tri[2] = 1;

				//  Upper right triangle.   
				tri[3] = 2;
				tri[4] = 3;
				tri[5] = 1;

				lineMesh.triangles = tri;
				lineMesh.RecalculateBounds();
				lineMesh.RecalculateNormals();
				return lineMesh;
		  }
	 }
}
