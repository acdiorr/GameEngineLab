using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Bullet")
        {
            Debug.Log("Fruit Shot Down! + 100 ");
            ScoreManager.instance.ChangeScore(100);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
