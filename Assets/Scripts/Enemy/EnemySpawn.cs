using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy1;
    public List<Transform> enemy1Position;
    public GameObject enemy2;
    public List<Transform> enemy2Position;

    void Awake()
    {
        if (enemy1 != null)
        {
            for (int i = 0; i < enemy1Position.Count; i++)
            {
                Instantiate(enemy1, enemy1Position[i].position, enemy1Position[i].rotation);
            }
        }
        if (enemy2 != null)
        {
            for (int i = 0; i < enemy2Position.Count; i++)
            {
                Instantiate(enemy2, enemy2Position[i].position, enemy1Position[i].rotation);
            }
        }
    }
}
