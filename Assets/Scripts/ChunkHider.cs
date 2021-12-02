using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHider : MonoBehaviour
{
    private Terrain[] chunks;

    public float visibleDistance;
    public int chunkSize;
    public float checkRate;

    private void Start()
    {
        chunks = FindObjectsOfType<Terrain>();
        InvokeRepeating("CheckChunks", 0.0f, checkRate);
    }

    private void CheckChunks()
    {
        Vector3 playerPos = transform.position;
        playerPos.y = 0;

        foreach(Terrain chunk in chunks)
        {
            Vector3 chunkCenterPos = chunk.transform.position + new Vector3(chunkSize / 2, 0, chunkSize / 2);

            chunk.gameObject.SetActive(Vector3.Distance(playerPos, chunkCenterPos) <= visibleDistance);
        }
    }
}
