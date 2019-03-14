using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    [Header("Board Details")]
    [SerializeField] GameObject blackTile;
    [SerializeField] GameObject whiteTile;
    [SerializeField] int boardWidth = 8;
    [SerializeField] int boardHeight = 8;

    private List<GameObject> tilesList;

    private bool boardPlayable = false;

	// Use this for initialization
	void Start () {
        tilesList = new List<GameObject>();

        // Create playing board. Default is 8x8
        // First check we have the prefabs and correct board width
        if (blackTile != null && whiteTile != null && boardWidth > 0 && boardHeight > 0)
        {
            boardPlayable = true;
            
            bool tileSwap = true;
            for(int i = 0; i < boardHeight; i++)
            {
                for(int j = 0; j < boardWidth; j++)
                {
                    // Create new tile
                    GameObject newTile = Instantiate(tileSwap ? blackTile : whiteTile, this.transform);
                    newTile.transform.position = new Vector3(j * 10f, 0f, i * 10f);
                    tilesList.Add(newTile);
                    // Swap tile
                    tileSwap = !tileSwap;
                }
                // Swap tile again as its a new row
                tileSwap = !tileSwap;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isBoardPlayable()
    {
        return boardPlayable;
    }

    public GameObject getTile(int x, int y)
    {
        return tilesList[y * boardWidth + x];
    }

    public List<GameObject> getAllTiles()
    {
        return tilesList;
    }
}
