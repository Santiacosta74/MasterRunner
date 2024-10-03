using UnityEngine;

public class FloorTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    public FloorTile Setup(GroundSpawner groundSpawner)
    {
        this.groundSpawner = groundSpawner;
        return this;
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2f);
    }
}
