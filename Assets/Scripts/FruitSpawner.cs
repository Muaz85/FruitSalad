using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	public GameObject WaterMilloinPrefab/*,RedApplPrefab, GrrenApplPrefab, orangePrefab,pinapplePrefab*/;
	public Transform[] spawnPoints;
   
	public float minDelay = .1f;
	public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnFruits());
    }

    private void Update()
    {
      
    }
    IEnumerator SpawnFruits ()
	{
		while (playSound.Startcreatfruit)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedWaterMilloin = Instantiate(WaterMilloinPrefab, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedRedAppl = Instantiate(RedApplPrefab, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedGrrenAppl = Instantiate(GrrenApplPrefab, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedorange = Instantiate(orangePrefab, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedpinapple = Instantiate(pinapplePrefab, spawnPoint.position, spawnPoint.rotation);

            Destroy(spawnedWaterMilloin, 5f);
            //Destroy(spawnedRedAppl, 5f);
            //Destroy(spawnedGrrenAppl, 5f);
            //Destroy(spawnedorange, 5f);
            //Destroy(spawnedpinapple, 5f);
        }
	}
	
}
