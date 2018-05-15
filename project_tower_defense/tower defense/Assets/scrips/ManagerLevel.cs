using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLevel : MonoBehaviour {

    [SerializeField]
    private GameObject tile;

    public float TileSize
    {
        get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; } // высчитываем как много у нас плиток 

    }
    // Use this for initialization
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CreateLevel()
    {

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y=0;y<20;y++)
        {
            
            for (int x=0;x<30;x++)
            {
                placeTile(x, y,worldStart);
            }
        }
   
    }
    private void placeTile(int x, int y,Vector3 worldStart)
    {
        GameObject newTiles = Instantiate(tile);

        newTiles.transform.position = new Vector3(worldStart.x + TileSize * x, worldStart.y- TileSize * y, 0); // изменяем позиции
    }

}
