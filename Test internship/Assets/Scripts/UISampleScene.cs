using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISampleScene : MonoBehaviour
{
    [SerializeField] private Text coins;
    [SerializeField] private Objects objects;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject lossPanel;

    public void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        AmountOfCoins();
    }

    void AmountOfCoins()
    {
        int amountOfCoins = 0;
        for (int i = 0; i < objects.Coins.Length; i++)
        {
            if (objects.Coins[i].activeInHierarchy)
            {
                amountOfCoins += 1;
            }
        }
        if(amountOfCoins == 0)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0;
        }
        coins.text = amountOfCoins.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Loss()
    {
        lossPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
