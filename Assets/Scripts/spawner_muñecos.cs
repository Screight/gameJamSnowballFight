using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_muñecos : MonoBehaviour
{
    public GameObject muñeco;

    public float spawnIntervalPublico;
    private float spawnInterval;

    private int maxMuñecos = 3;

    private BoxCollider spawnRange;

    private void Update()
    {
        if(GameManager.Instance.SnowmanCounter < 3)
        {
            spawnInterval -= Time.deltaTime;
            if (spawnInterval <= 0)
            {
                StartCoroutine(spawnMuñecos());
                spawnInterval = spawnIntervalPublico;
            }
        }
    }

    private IEnumerator spawnMuñecos() {

        Debug.Log("iniciando spawner");

        spawnRange = GameObject.FindGameObjectWithTag("destino_bola_grande").GetComponent<BoxCollider>();

        Vector3 spawnPosition;
        spawnPosition.x = Random.Range(spawnRange.transform.position.x - spawnRange.size.x / 2, spawnRange.transform.position.x + spawnRange.size.x / 2);
        spawnPosition.y = 0.5f;
        spawnPosition.z = Random.Range(spawnRange.transform.position.z - spawnRange.size.z / 2, spawnRange.transform.position.z + spawnRange.size.z / 2);
        
        if (GameManager.Instance.SnowmanCounter < maxMuñecos)
        {
            Debug.Log("spawneando muñeco");
            GameObject muñecoSpawned = Instantiate(muñeco, spawnPosition, muñeco.transform.rotation);
            GameManager.Instance.SnowmanCounter++;
        }

        yield return new WaitForSeconds(spawnInterval);

    }
}
