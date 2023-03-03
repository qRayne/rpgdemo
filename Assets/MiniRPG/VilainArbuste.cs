using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilainArbuste : MonoBehaviour
{
    [SerializeField]
    private Transform prefabExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
