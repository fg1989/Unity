using UnityEngine;

public class MouvementNuage : MonoBehaviour
{
    public float speed;
    public bool Ignore = false;

    public void Start()
    {
        if (!Ignore)
        {
            transform.position = new Vector3(Random.Range(-7f, 7f), 6, -1);
        }
    }

    public void Update()
    {
        transform.Translate(0, -Time.deltaTime * speed, 0);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
