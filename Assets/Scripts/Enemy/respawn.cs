using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] trans;
    public Transform[] WallsForMovableEnemy;

    private float delayTimer = (float) 0.8;

    private void Start()
    {
        Instantiate(enemy[0], trans[0].position, trans[0].rotation);
        Instantiate(enemy[0], trans[1].position, trans[1].rotation);
        Instantiate(enemy[0], trans[2].position, trans[2].rotation);
    }

    private void Update()
    {

    }

    public void spawnEnemy(string tag, Vector3 position, Quaternion rotation)
    {
        Debug.Log("Here is the tag"+tag);
        if(tag.Equals("Respawn"))
            StartCoroutine(respawnDelay(enemy[0],position, rotation));
        if (tag.Equals("RespawnFiring"))
            StartCoroutine(respawnDelayMovable(enemy[1], position, rotation));
    }


    IEnumerator respawnDelay(GameObject enemy, Vector3 position, Quaternion rotation) {
        yield return new WaitForSeconds(delayTimer);
        Instantiate(enemy, position, rotation);
    }

    IEnumerator respawnDelayMovable(GameObject enemy, Vector3 position, Quaternion rotation)
    {
        yield return new WaitForSeconds(delayTimer);
        GameObject mob = Instantiate(enemy, position, rotation);
        mob.GetComponent<RandomMove>().points = WallsForMovableEnemy;
    }
}
