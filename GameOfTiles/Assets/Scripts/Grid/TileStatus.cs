using UnityEngine;
using System.Collections;

public class TileStatus : MonoBehaviour {

    public CellStatus _cellStatus;
    public enum CellStatus {
        Empty,
        Player1,
        Player2,
        Player3,
        Player4,
        Player5,
        player6
    };


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.A)){
			_cellStatus = CellStatus.Player1;
			Debug.LogFormat ("hey this cell status has changed");
		}
	}
}
