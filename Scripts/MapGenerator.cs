using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapSize = 3;
    public List<GameObject> rooms;
    public float roomSize = 100;
    public Transform parent;
    Vector2 nextRoomPos;

    void Start()
    {

        nextRoomPos = new Vector2((-mapSize*roomSize)/2, (roomSize*mapSize)/2);

        for (int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {

                int r = Random.Range(0, rooms.Count); 

                Instantiate(rooms[r], new Vector3(nextRoomPos.x,nextRoomPos.y,0), gameObject.transform.rotation,parent);
                nextRoomPos.y -= roomSize;
            }
            nextRoomPos.x += roomSize;
            nextRoomPos.y = (roomSize * mapSize)/2;
        }
    }


}
