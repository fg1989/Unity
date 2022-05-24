using UnityEngine;

public class Joueur : MonoBehaviour
{
    public int speed;
    public float jumpForce;

    private Collider2D child;
    public GameObject nuage;

    private int compteur;
    private readonly float delai = 1.5f;
    private float time = 0;

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

    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && rigidbody.velocity.y <= 0 && child.OverlapCollider(new ContactFilter2D(), temp) == 2)
        {
            rigidbody.AddForce(new Vector2(0, jumpForce));
        }

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

        if (Time.time > time + delai)
        {
            if (compteur < 30)
            {
                time = Time.time;
                Instantiate(nuage);
                compteur++;
            }
            else if (compteur == 30)
            {
                GameObject nuageFinal = Instantiate(nuage);
                nuageFinal.GetComponent<CapsuleCollider2D>().isTrigger = true;
                nuageFinal.GetComponent<CapsuleCollider2D>().usedByEffector = false;
                Destroy(nuageFinal.GetComponent<PlatformEffector2D>());
                compteur++;
            }
        }
    }

    private new Rigidbody2D rigidbody;

    private static readonly Collider2D[] temp = new Collider2D[2];
}