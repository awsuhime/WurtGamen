using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawnManager : MonoBehaviour
{
    private int enemiesLeft;

    private int enemys = 0;
    private int wave = 0;
    private bool waveEndUp;

    public float spawnLower = 2.5f;
    public float spawnUpper = 4f;

    public GameObject wavewEndUI;

    private bool spawning = false;
    public GameObject[] enemies;
    public TextMeshProUGUI waveText;

    private SimplePlayer simplePlayer;
    public GameObject player;
    void Start()
    {
        simplePlayer = player.GetComponent<SimplePlayer>();
    }

    void Update()
    {
        enemiesLeft = FindObjectsOfType<enemy>().Length;
        if (!waveEndUp && enemiesLeft == 0 && enemys == 0)
        {
            wavewEndUI.SetActive(true);
            waveEndUp = true;
            wave++;
            waveText.text = ("wave: " + wave);
            simplePlayer.movable = false;
        }
        if (!spawning && enemys > 0)
        {
            StartCoroutine (Spawn());
        }
    }

    void BeginWave()
    {

    }

    System.Collections.IEnumerator Spawn()
    {
        spawning = true;
        if (enemys > 0)
        {
            Instantiate(enemies[0], generateSpawn(), Quaternion.Euler(0,180,0));
            enemys -= 1;
            Debug.Log("enemies left " + enemys);
        }
        if (enemys > 0)
        {
            yield return new WaitForSeconds(Random.Range(spawnLower, spawnUpper));
        }
        else
        {
            spawning = false;
            yield break;
        }
        
        spawning = false;
    }

    private Vector3 generateSpawn()
    {
        Vector3 spawnpos = new (Random.Range(-10f,10f), 0.7f, Random.Range(60f, 70f));
        return spawnpos;       
    }
    
    public void waveStart()
    {
        enemys = 6 + wave;
        Debug.Log("new wave started. enemys: " + enemys);
        wavewEndUI.SetActive(false);
        waveEndUp = false;
        simplePlayer.movable = true;
        
    }


}
