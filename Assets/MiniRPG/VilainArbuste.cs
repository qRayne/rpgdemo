using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilainArbuste : MonoBehaviour
{
    [SerializeField]
    private Transform prefabExplosion;

    [SerializeField]
    private Transform cible;
    private string nomCible;


    // Start is called before the first frame update
    void Start()
    {
        // pour recupérer un game object
        GameObject obj = GameObject.Find(nomCible);
        Debug.Assert(obj != null,"la cible nommée" +nomCible + " n'existe pas");

        if (obj)
        {
            cible = obj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cible)
        {
            Vector3 direction = cible.position - transform.position;
            Debug.DrawRay(transform.position, direction.normalized, Color.green);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Arme")
        { 
            Destroy(this.gameObject);
            Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        }
    }
}
