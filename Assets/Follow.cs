using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
   public GameObject player;
    public float speed; 
    public float distanceBetween;
    private float distance; 
    Vector2 direction;


    // Start is called before the first frame update
    // void Awake()
    // {
    //     StartCoroutine("FindPlayer");
    // }

    // Update is called once per frame
    void Update()
    {
 
          
            distance = Vector2.Distance(transform.position, player.transform.position);
            direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if(distance < distanceBetween)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
    
        
    }

    // IEnumerator FindPlayer()
    // {
    //     yield return new WaitForSeconds(3);
        
    //     followSnake = GameObject.FindObjectsOfType<MarkerManger>();
        


    // }
}
