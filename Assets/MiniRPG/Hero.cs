using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    private Rigidbody2D rig;
    private Vector2 mouvement;
    public float vitesse;
    private Animator anim;
    public int nbCoins;
    public bool detruire = false;    


    [SerializeField]
    private Transform prefabFleche;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", mouvement.x);
        anim.SetFloat("Vertical", mouvement.y);

        if (Input.GetButtonDown("Tirer"))
        {
            Instantiate(prefabFleche, transform.position, Quaternion.identity);
        }

        detruire = Input.GetButton("Fire1");
    }

    void FixedUpdate()
    {
        rig.velocity = mouvement * vitesse;
        rig.velocity = rig.velocity.normalized * vitesse;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Objet")
        {
            nbCoins++;
            Debug.Log(nbCoins);
        }

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Ennemi")
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (nbCoins >= 3 && detruire)
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
