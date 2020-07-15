using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public GameObject fire;
    public Collider2D spawnPath;
    private float spawnPeriod = 3f;

    private float timer;
    private Vector2 spawnLocation;
    public static int fireCount = 0;

    void Start()
    {
        spawnPath = spawnPath.GetComponent<Collider2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Mathf.Max(spawnPeriod, 0.5f))
        {
            timer = 0f;
            Instantiate(fire,
                        spawnLocation = Random.insideUnitCircle.normalized,
                        Quaternion.FromToRotation(Vector3.up, (Vector3)spawnLocation - spawnPath.bounds.center),
                        spawnPath.transform);
            fireCount++;
            spawnPeriod -= 0.1f;
        }
    }
}
