using UnityEngine;

public class MouvementRocher : MonoBehaviour
{
    public float speed;
    public bool final = false;

    public void Start()
    {
        float pos = Random.Range(MouvementBateau.minY, MouvementBateau.maxY);
        transform.position = new Vector3(transform.position.x, pos, pos);
    }

    public void Update()
    {
        transform.Translate(-Time.deltaTime * speed, 0, 0);

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}