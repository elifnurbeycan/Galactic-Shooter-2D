using System.Collections;
using UnityEngine;

public class SpawnManager_sc : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject[] bonusPrefabs;

    [SerializeField]
    GameObject enemyContainer;

    [SerializeField]
    bool stopSpawning = false;

    void Start()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f); // soluklanma süresi 

        while (stopSpawning == false)
        {
            Vector3 position = new Vector3(Random.Range(-9.5f, 9.5f),
                                                    7.4f,
                                                    0);
            GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            enemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnBonusRoutine()
    {
        while (stopSpawning == false)
        {
            int waitTime = Random.Range(5, 10);
            Debug.Log("Üçlü atış bekleme süresi: " + waitTime);
            yield return new WaitForSeconds((float)waitTime);

            Vector3 position = new Vector3(Random.Range(-9.18f, 9.18f),
                                                    7.7f,
                                                    0);
            int randomBonus = Random.Range(0, 3);
            Instantiate(bonusPrefabs[randomBonus], position, Quaternion.identity);
        }
    }
  
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }
    
    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }
}
