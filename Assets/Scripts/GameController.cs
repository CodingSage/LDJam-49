using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public GameObject player;
    public List<GameObject> healthBar;

    private Destructible playerDestructible;
    private int currentHealth;

    void Start()
    {
        playerDestructible = player.GetComponent<Destructible>();
        currentHealth = playerDestructible.GetHitPoints();
    }

    void Update()
    {
        if (currentHealth != playerDestructible.GetHitPoints())
        {
            currentHealth = playerDestructible.GetHitPoints();
            for (int i = healthBar.Count-1; i >= 0; i--)
            {
                GameObject healthIndicator = healthBar[i];
                healthIndicator.SetActive(i < currentHealth);
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
