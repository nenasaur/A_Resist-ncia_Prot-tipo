using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
              //part of the code that changes the X-axis position of the trees
        transform.position = new Vector2(
            transform.position.x + speed * Time.deltaTime,
            transform.position.y
        );

        if(transform.position.x > 40){
            Destroy(gameObject);
        }
    }
 
}
