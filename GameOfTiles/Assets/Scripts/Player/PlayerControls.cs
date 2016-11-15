using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	Camera cam; 
	GameObject _spawnedTile;
	GameObject _selectedCell; 
	bool _tileSpawned = false;
	// Use this for initialization

	void Start () {
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
	}

	//instanicate what ever prefab the card is attached too
	//the tile would follow the players mouse cursor untill they let go over a valid gridspace or back in there hand. 
	//once placed a call a fucntion that generates the stats for this tile. 
	//once placed remove the tile from the players hand. 

	void PlaceCard(){
		_spawnedTile = Instantiate(Resources.Load ("Prefabs/Environment/" + "Temp_Environment_Tile")) as GameObject;
		_tileSpawned = true;
	}
 	
	//will also control the game camrea 

	//and deal with selecting units on the play area

	// Update is called once per frame
	void Update () {

		#region Land Placement
		if (Input.GetMouseButton (0)) {
			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "Card" && _spawnedTile != true) {
					print ("This is what i hit: " + hit.collider.ToString ());
					//In here create something that pulls what type of card to place from the gameobject. 
					PlaceCard ();
					_spawnedTile.SetActive (false);
				
				} else if (hit.collider.tag == "Cell") {
					try {
						_spawnedTile.SetActive (true);
						_selectedCell = hit.collider.gameObject;
						_spawnedTile.transform.position = new Vector3 (_selectedCell.gameObject.transform.position.x, -81.78f, _selectedCell.gameObject.transform.position.z);

					} catch {
						print ("thing has been cought");
					}
				} else if (hit.collider.tag == "Card" && _spawnedTile == true) { //Returns card to the players hand
					Destroy (_spawnedTile);
				}
			}	
		} else if (Input.GetMouseButtonUp(0)){    		//Resets placement variables
		//	_selectedCell.GetComponentInParent<CustomCell>();

			//_spawnedTile = null;
			//_tileSpawned = false;
		}
		#endregion
	
	}
}