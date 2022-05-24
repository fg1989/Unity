using UnityEngine;

public class ApparitionNuage : MonoBehaviour
{
    public GameObject nuage;

    private int compteur;
    private float time;
    private readonly float delai = 1.5f;

    public void Update()
    {
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
}