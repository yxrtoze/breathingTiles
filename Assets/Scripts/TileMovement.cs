using UnityEngine;

public class TileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the tile movement
    private Renderer tileRenderer;
    private Color originalColor;
    private Color clickedColor = Color.red;

    private bool isBeingClicked = false; // Track if the tile is being clicked
    private float clickDuration = 0f; // Timer for how long the tile is clicked
    private float requiredClickTime = 2f; // Time in seconds to hold click
    private bool isWhite = false; // Flag to track if tile is white after holding

    private void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        originalColor = tileRenderer.material.color; // Save the tile's original color
    }

    private void Update()
    {
        MoveTile(); // Continuously move the tile

        if (isBeingClicked && !isWhite)
        {
            clickDuration += Time.deltaTime;

            // If clicked for the required time, change color to white and keep it white
            if (clickDuration >= requiredClickTime)
            {
                tileRenderer.material.color = Color.white;
                isBeingClicked = false; // Stop tracking the click
                clickDuration = 0f; // Reset the click timer
                isWhite = true; // Mark the tile as white
            }
        }
    }

    private void MoveTile()
    {
        float movement = speed * Time.deltaTime;
        transform.Translate(Vector3.back * movement); // Move tile in the negative Z direction
    }

    private void OnMouseDown()
    {
        // Triggered when the tile is clicked
        if (!isWhite) // Only change to red if the tile is not already white
        {
            isBeingClicked = true;
            tileRenderer.material.color = clickedColor; // Change color to red
        }
    }

    private void OnMouseUp()
    {
        // Triggered when the click is released
        if (!isWhite) // Reset to original color if the tile hasn't turned white yet
        {
            isBeingClicked = false;
            clickDuration = 0f; // Reset the click duration
            tileRenderer.material.color = originalColor; // Revert to original color
        }
    }
}
