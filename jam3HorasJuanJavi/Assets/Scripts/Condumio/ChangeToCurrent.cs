using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToCurrent : MonoBehaviour
{
    public Material matCurrentTile;
    public Material matDefaultTile;

    public Renderer smallTileOnMap;
    public Renderer floorTile;
    public List<Renderer> otherTiles;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") )
        {
            smallTileOnMap.material = matCurrentTile;
            floorTile.material = matCurrentTile;

            for( int i = 0; i < otherTiles.Count; i++ )
            {
                otherTiles[i].material = matDefaultTile;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") )
        {
            smallTileOnMap.material = matDefaultTile;
            floorTile.material = matDefaultTile;
        }
    }
}
