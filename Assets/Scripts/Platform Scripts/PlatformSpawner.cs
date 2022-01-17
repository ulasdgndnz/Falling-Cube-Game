using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatforms;
    public Text testText;
    public Text testText2;

    public float platformSpawnTimer = 2f;
    private float currentPlatformSpawnTimer;

    private int platformSpawnCount;

    public float minX = -2f, maxX = 2f;

    // Start is called before the first frame update
    void Start()
    {
        testText.gameObject.SetActive(false);
        testText2.gameObject.SetActive(false);
        currentPlatformSpawnTimer = platformSpawnTimer;

    }

    // Update is called once per frame
    void Update()
    {
        testText.text = 
            ($"Spawn Count: {platformSpawnCount.ToString()} \nCurrent Timer: {currentPlatformSpawnTimer}");
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        // Platform Spawner Sayacı
        currentPlatformSpawnTimer += Time.deltaTime;
        
        // 
        if (currentPlatformSpawnTimer >= platformSpawnTimer)
        {
            platformSpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if (platformSpawnCount < 2) 
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            } else if (platformSpawnCount == 2)
            {
                int random = Random.Range(0, 2);
                if (random > 0)
                {
                    testText2.text = "platformPrefab";
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    testText2.text = "movingPlatforms";
                    newPlatform = Instantiate(
                        movingPlatforms[Random.Range(0, movingPlatforms.Length)], temp, Quaternion.identity);
                }
            } else if (platformSpawnCount == 3)
            {
                int random = Random.Range(0, 2);
                if (random > 0)
                {
                    testText2.text = "platformPrefab";
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    testText2.text = "spikePlatformPrefab";
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            } else if (platformSpawnCount == 4)
            {
                int random = Random.Range(0, 2);
                if ( random > 0)
                {
                    testText2.text = "newPlatform";
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    testText2.text = "breakablePlatforms";
                    newPlatform = Instantiate(breakablePlatforms, temp, Quaternion.identity);
                }

                platformSpawnCount = 0;
            }

            if (!(newPlatform is null)) newPlatform.transform.parent = transform; // For better hierarchy
            currentPlatformSpawnTimer = 0f;

        } // Spawn Platform
        
        
    }
}
