using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    [SerializeField] private SpawnerDestroyer spawner; // Reference to the spawner

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tile")) // Ensure the colliding object is tagged as "Tile"
        {
            spawner.SpawnTile(); // Trigger spawning the next tile
        }
    }
}
