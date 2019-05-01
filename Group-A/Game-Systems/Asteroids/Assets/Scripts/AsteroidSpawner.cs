using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public GameObject[] asteroidPrefabs; // Array of prefabs to spawn
        public float spawnRate = 1f; // Rate of spawn (in seconds)
        public float spawnRadius = 5f; // Distance to spawn each asteroid
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        void Spawn()
        {
            //Randomize a position
            Vector2 rand = Random.insideUnitCircle * spawnRadius;
            // Offset position from spawner location
            Vector2 position = (Vector2)transform.position + rand;
            // Generate a random index into prefab array
            int randIndex = Random.Range(0, asteroidPrefabs.Length);
            // Get random asteroid using index
            GameObject randAsteroid = asteroidPrefabs[randIndex];
            // Clone random asteroid - Quaternion.identity means default rotation (0)
            Instantiate(randAsteroid, position, Quaternion.identity); // Makes a copy and puts in scene
        }

        // Use this for initialization
        void Start()
        {
            InvokeRepeating("Spawn", 0, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Reset();
        }
    }
}
