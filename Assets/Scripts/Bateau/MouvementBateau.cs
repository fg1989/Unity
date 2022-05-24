using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementBateau : MonoBehaviour
{
    // L'intéret de mettre un champ public, c'est que l'on peut le modifier directement depuis unity
    public float speed;

    public const float minY = -4.2f;
    public const float maxY = -0.55f;

    private float mouvement;
    private const float x = -7.55f;
    private const float z = -5;

    public void OnHorizontal(InputValue value)
    {
        mouvement = value.Get<float>();
    }

    public void Update()
    {
        float newY = transform.position.y + (speed * Time.deltaTime * mouvement);

        if (newY > maxY)
        {
            newY = maxY;
        }
        else if (newY < minY)
        {
            newY = minY;
        }

        transform.position = new Vector3(x, newY, z);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MouvementRocher>().final)
        {
            CustomSceneManager.GoNextLevelMessage();
            Destroy(gameObject);
        }
        else
        {
            CustomSceneManager.GoDead();
            Destroy(gameObject);
        }
    }
}