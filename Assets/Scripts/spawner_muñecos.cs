using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_muñecos : MonoBehaviour
{
    public GameObject muñeco;

    public float spawnIntervalPublico;
    private float spawnInterval;

    private int muñecosSpawned;
    private int maxMuñecos = 3;

    private BoxCollider spawnRange;

    private void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0) {
            StartCoroutine(spawnMuñecos());
            spawnInterval = spawnIntervalPublico;
        }
    }

    private IEnumerator spawnMuñecos() {

        Debug.Log("iniciando spawner");

        spawnRange = GameObject.FindGameObjectWithTag("destino_bola_grande").GetComponent<BoxCollider>();

        Vector3 spawnPosition;
        spawnPosition.x = Random.Range(spawnRange.transform.position.x - spawnRange.size.x / 2, spawnRange.transform.position.x + spawnRange.size.x / 2);
        spawnPosition.y = 1;
        spawnPosition.z = Random.Range(spawnRange.transform.position.z - spawnRange.size.z / 2, spawnRange.transform.position.z + spawnRange.size.z / 2);
        
        if (muñecosSpawned < maxMuñecos)
        {
            Debug.Log("spawneando muñeco");
            GameObject muñecoSpawned = Instantiate(muñeco, spawnPosition, muñeco.transform.rotation);
            muñecosSpawned++;
        }

        yield return new WaitForSeconds(spawnInterval);

    }
}
