using UnityEngine;
using UnityEngine.InputSystem;

public class Joueur : MonoBehaviour
{
    public int speed;
    public float jumpForce;

    private float mouvement;
    private Collider2D child;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        child = transform.GetChild(0).GetComponent<CircleCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlatformEffector2D _))
        {
            CustomSceneManager.GoNextLevelMessage();
        }
    }

    public void OnMove(InputValue value)
    {
        mouvement = value.Get<float>();
    }

    public void OnSaut()
    {
        if (rigidbody.velocity.y <= 0 && child.OverlapCollider(new ContactFilter2D(), temp) == 2)
        {
            rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void Update()
    {
        transform.Translate(speed * Time.deltaTime * mouvement, 0, 0);

        if (transform.position.y < -10)
        {
            CustomSceneManager.GoDead();
        }

        if (transform.position.x < -9)
        {
            transform.position = new Vector3(8.5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 9)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, transform.position.z);
        }
    }

    private new Rigidbody2D rigidbody;

    private static readonly Collider2D[] temp = new Collider2D[2];
}