using UnityEngine;

public class Objects : MonoBehaviour
{
    [SerializeField] private int N;
    [SerializeField] private GameObject[] coins;
    [SerializeField] private GameObject[] spikes;
    public GameObject[] Coins
    {
        get { return coins; }
    }
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject spike;

    private void Start()
    {
        coins = new GameObject[N];
        spikes = new GameObject[N];

        for(int i = 0; i < coins.Length; i++)
        {
            coins[i] = Instantiate(coin, new Vector2(Random.Range(-4, 4), Random.Range(-4, 4)), Quaternion.identity);
            spikes[i] = Instantiate(spike, new Vector2(Random.Range(-4, 4), Random.Range(-4, 4)), Quaternion.identity);
        }

        
    }
}
