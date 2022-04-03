using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpawnCoordinates
{
    static List<List<Vector2>> coordinates = new List<List<Vector2>> { 
        new List<Vector2> {new Vector2(0f,-1f), new Vector2(-1f,1f), new Vector2(1f,1f)}, 
        new List<Vector2> {new Vector2(0f,-1f), new Vector2(-1f,0f), new Vector2(0f,1f), new Vector2(1f,0f) } };
    public static List<Vector2> GetSpawnCoordinates(int players)
    {
        int index = players - 3;
        return coordinates[index];
    }
}
