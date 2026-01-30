using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject moveObject;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject spawnObject;

    void Start()
    {
        // Spawns one at the player's position when the game starts
        SpawnAtPlayer();
    }

    void Update()
    {
        // Player Movement
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(x, y).normalized;

        if (moveObject != null)
        {
            moveObject.transform.Translate(move * Time.deltaTime * speed);
        }

        // Click to spawn a new object exactly where the player is
        if (Input.GetMouseButtonDown(0))
        {
            SpawnAtPlayer();
        }
    }

    void SpawnAtPlayer()
    {
        if (spawnObject != null && moveObject != null)
        {
            // This takes the current position of your moveObject (the player)
            Vector3 playerPos = moveObject.transform.position;

            // Spawn the object at that specific location
            Instantiate(spawnObject, playerPos, Quaternion.identity);

            Debug.Log("Clone created at player position: " + playerPos);
        }
    }
}