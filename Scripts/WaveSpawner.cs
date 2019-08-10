using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;
    public Wave[] waves;

    public Transform spwanPoint;

    public float timeBetweenWaves = 5f;

    public Text waveCountDownText;

    private float countdown = 10f;

    private int waveIndex = 0;

    public GameManager gameManager;

    

    void Update ()
    {
        if (EnemiesAlive > 0)
         return;
        
        

        if (waveIndex == waves.Length && EnemiesAlive == 0 && GameOver.gameOver == false)
        {
            gameManager.Winlevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpwanWave());
            countdown = timeBetweenWaves;
            return;

        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countdown); 
    }

    
    IEnumerator SpwanWave ()
    {


        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
   
        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count ; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        GameOver.gameOver = false;
       
    }

    void SpawnEnemy (GameObject enemy)
    {
        Instantiate(enemy, spwanPoint.position, spwanPoint.rotation);
    }
         


}
