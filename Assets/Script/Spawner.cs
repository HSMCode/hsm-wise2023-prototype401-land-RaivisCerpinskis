using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectToSpawnArray;
    public float spawnInterval = 1.0f;
    public float spawnSpeed = 5.0f;
    public float spawnZPosition = 0.0f;
    public float minXPosition = 10.0f;
    public float maxXPosition = 10.0f;

    private void Start()
    {
        InvokeRepeating("SpawnObject", 0.0f, spawnInterval);
    }

    private void SpawnObject()
    {
        GameObject selectedObject = objectToSpawnArray[Random.Range(0, objectToSpawnArray.Length)];

        GameObject spawnedObject = Instantiate(selectedObject, transform.position, Quaternion.identity);

        Vector3 spawnPosition = new Vector3(Random.Range(minXPosition, maxXPosition), transform.position.y, spawnZPosition);
        spawnedObject.transform.position = spawnPosition;

        spawnedObject.AddComponent<MoveLeft>();
        MoveLeft moveLeftScript = spawnedObject.GetComponent<MoveLeft>();

        moveLeftScript.speed = spawnSpeed;
        moveLeftScript.destroyXPosition = -10.0f;
    }
}

public class MoveLeft : MonoBehaviour
{
    public float speed = 5.0f;
    public float destroyXPosition = -10.0f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}