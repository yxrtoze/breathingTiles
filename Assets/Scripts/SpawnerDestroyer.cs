using UnityEngine;

public class SpawnerDestroyer : MonoBehaviour
{
    [Header("Tile Prefabs")]
    [SerializeField] private GameObject inhaleTilePrefab; // Prefab for inhale tile
    [SerializeField] private GameObject holdTilePrefab;   // Prefab for hold tile
    [SerializeField] private GameObject exhaleTilePrefab; // Prefab for exhale tile

    [Header("Spawn Configuration")]
    [SerializeField] private Transform spawnPoint; // Reference for spawn position

    private string[] tileSequence = { "inhale", "hold", "exhale" }; // Sequence of tiles
    private int currentTileIndex = 0; // Track current tile in the sequence

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tile")) // Ensure the colliding object is tagged as "Tile"
        {
            Destroy(other.gameObject); // Destroy the tile
        }
    }

    public void SpawnTile()
    {
        GameObject tileToSpawn = null;
        Vector3 spawnPosition = spawnPoint.position; // Base spawn position

        // Determine which tile to spawn and its spawn position
        string tileType = tileSequence[currentTileIndex];
        switch (tileType)
        {
            case "inhale":
                tileToSpawn = inhaleTilePrefab;
                spawnPosition.x = -10f; // Lane 1
                spawnPosition.z = 145f;  // Inhale tile Z position
                break;

            case "hold":
                tileToSpawn = holdTilePrefab;
                spawnPosition.x = 0f;   // Lane 2
                spawnPosition.z = 145f; // Hold tile Z position
                break;

            case "exhale":
                tileToSpawn = exhaleTilePrefab;
                spawnPosition.x = 10f;  // Lane 3
                spawnPosition.z = 145f; // Exhale tile Z position
                break;
        }

        if (tileToSpawn != null)
        {
            Instantiate(tileToSpawn, spawnPosition, Quaternion.identity); // Spawn the tile
        }

        // Move to the next tile in the sequence
        currentTileIndex = (currentTileIndex + 1) % tileSequence.Length;
    }
}
