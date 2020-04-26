using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManagerScript;

    public ParticleSystem explosionParticle;

    private float minForce = 12;
    private float maxForce = 16;

    private float torqueRange = 10;

    private float xRange = 4;
    private float yRange = -2;

    public int pointValue;


    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPos();
    }

    private void OnMouseDown()
    {
        if (gameManagerScript.isGameActive)
        {
            GameObject.Find("Main Camera").GetComponent<CameraShake>().enabled = true;
            Destroy(gameObject);
            gameManagerScript.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManagerScript.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    float RandomTorque()
    {
        return Random.Range(-torqueRange, torqueRange);
    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), yRange);
    }
}
