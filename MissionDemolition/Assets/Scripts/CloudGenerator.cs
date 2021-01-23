using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public int numberOfClouds = 40;
    public GameObject cloudPrefab;
    public Vector3 positionFrom;
    public Vector3 positionTo;
    public float scaleFrom = 1;
    public float scaleTo = 5;
    public float cloudSpeedMultiplier = 0.5f;
    public Sprite[] cloudSprites;

    public GameObject[] cloudObjects;

    // Start is called before the first frame update
    void Awake()
    {
        cloudObjects = new GameObject[numberOfClouds];
        GameObject cloud;

        for (int i = 0; i < numberOfClouds; i++)
        {
            cloud = Instantiate(cloudPrefab);

            Vector3 cloudPosition = Vector3.zero;
            cloudPosition.x = Random.Range(positionFrom.x, positionTo.x);
            cloudPosition.y = Random.Range(positionFrom.y, positionTo.y);
            
            float cloudScale = Random.Range(scaleFrom, scaleTo);
            cloudPosition.y = Mathf.Lerp(positionFrom.y, cloudPosition.y, cloudScale);
            cloudPosition.z = 90 * cloudScale - 100;

            cloud.transform.position = cloudPosition;
            cloud.transform.localScale = Vector3.one * cloudScale;
            cloud.transform.parent = transform;

            cloud.GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(0,12)];
            cloudObjects[i] = cloud;
        }


    }

    // Update is called once per frame
    void Update()
    {
        foreach (var cloud in cloudObjects)
        {
            float scale = cloud.transform.localScale.x;

            cloud.transform.Translate(new Vector3(Time.deltaTime * cloudSpeedMultiplier * scale * -1, 0));

            if (cloud.transform.position.x < positionFrom.x)
            {
                var pos = cloud.transform.position;
                pos.x = positionTo.x;
                cloud.transform.position = pos;
            }
        }
    }
}
