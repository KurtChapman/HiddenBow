using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
	 public int gridSize;
	 public GameObject tile;
	 public List<Sprite> tileSet;

	 private List<List<GameObject>> activeGameTiles;
	 
	 // Use this for initialization
	 void Start()
	 {
		  activeGameTiles = new List<List<GameObject>>();
		  CreateLevel();
	 }

	 private void CreateLevel()
	 {
		  for (int i = 0; i < gridSize; i++)
		  {
				activeGameTiles.Add(new List<GameObject>());
				for (int j = 0; j < gridSize; j++)
				{
					 activeGameTiles[i].Add(CreateTile(new Vector2(i, j)));
				}
		  }
		  RepositionLevel();
	 }

	 private Vector3 GetTileSize(GameObject tile)
	 {
		  SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();
		  var size = renderer.sprite.bounds.size * tile.transform.localScale.x;
		  return size;
	 }

	 private void SetTileSprite(GameObject sprite)
	 {
		  SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();
		  var index = Random.Range(0, 10);
		  renderer.sprite = tileSet[index];
	 }

	 private GameObject CreateTile(Vector2 gridLocation)
	 {
		  var newTile = Instantiate(tile);

		  SetTileSprite(newTile);

		  var tileSize = GetTileSize(newTile);
		  newTile.transform.position = new Vector3(gridLocation.x * tileSize.x, gridLocation.y * tileSize.y, 1);

		  newTile.transform.parent = transform;

		  return newTile;
	 }

	 private void RepositionLevel()
	 {
		  var firstTile = activeGameTiles[0][0];

		  var size = GetTileSize(firstTile);

		  var totalGridSize = size * (gridSize * gridSize);
		  var shiftAmount = new Vector3(totalGridSize.x / firstTile.transform.localScale.x, totalGridSize.y / firstTile.transform.localScale.x, 0);

		  for (int i = 0; i < gridSize; i++)
		  {
				for (int j = 0; j < gridSize; j++)
				{
					 activeGameTiles[i][j].transform.position -= shiftAmount;
				}
		  }
	 }
}
