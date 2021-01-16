using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 1f;
    public float edgeDistance = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetwwenAppleDrops = 1f;

    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine("DropApple");
        StartCoroutine("ChangeDistanceAtRandom");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime * direction);

        if (Mathf.Abs(transform.position.x) > 10)
        {
            direction *= -1;
        }

    }

    IEnumerator ChangeDistanceAtRandom()
    {
        while (true)
        {
            if (Random.value < chanceToChangeDirections)
            {
                direction *= -1;
            }
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

        }
    }


    public IEnumerator DropApple(){
        // drop apple
        while (true)
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            yield return new WaitForSeconds(1);
        }
    }
}
