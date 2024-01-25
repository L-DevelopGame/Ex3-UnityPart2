using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedCarRandSpawner1 : MonoBehaviour
{
    [SerializeField] DirectionMover[] cars;
   // [SerializeField] DirectionMover[] heavyCarPrefabsToSpawn;
    [SerializeField] float velocityOfSpawnCar;
    [Tooltip("Minimum time between spawns, in seconds")][SerializeField] float minTimeBetweenSpawnsCar = 3f;
    [Tooltip("Maximum time between spawns, in seconds")][SerializeField] float maxTimeBetweenSpawnsCar = 4f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")][SerializeField] float maxXDistance = 0.5f;
    [Tooltip("The direction vector of the prefabs")][SerializeField] private Vector3 direction;

    void Start()
    {
        this.StartCoroutine(SpawnRoutine());  
        
    }

    IEnumerator SpawnRoutine()
    {   
        // SpawnRoutine
        while (true)
        {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawnsCar, maxTimeBetweenSpawnsCar);
            int randCarType = Random.Range(0, 2);
            DirectionMover[] currectCars = cars;
            float carsSpeed = velocityOfSpawnCar;
            int randomCar = Random.Range(0, currectCars.Length);

            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       
            // await Task.Delay((int)(timeBetweenSpawnsInSeconds*1000));       // async-await
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);

            // Rotate the cars according to the direction vector
            Quaternion rotationOfSpawnedObject = Quaternion.Euler(0, 0, -Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

            GameObject newObject = Instantiate(currectCars[randomCar].gameObject, positionOfSpawnedObject, rotationOfSpawnedObject);
            DirectionMover directionMover = newObject.GetComponent<DirectionMover>();
            directionMover.SetDirection(direction);
            directionMover.SetVelocity(carsSpeed);
        }
    }
}
