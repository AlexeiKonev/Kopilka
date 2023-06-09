using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public List<GameObject> coinsList;
    public GameObject coinPrefab;
    public Transform spawnPoint;

    private List<int> spawnedCoinIndexes = new List<int>();

    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        Spawn();
    }

    //IEnumerator Spawner()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(2f);


    //    }
    //}

    int GetUniqueRandomIndex()
    {
        int randomIndex = Random.Range(0, coinsList.Count);

        // ѕровер€ем, чтобы монета с таким индексом еще не была создана
        while (spawnedCoinIndexes.Contains(randomIndex))
        {
            randomIndex = Random.Range(0, coinsList.Count);
        }

        // ƒобавл€ем индекс в список уже созданных монет
        spawnedCoinIndexes.Add(randomIndex);

        // ≈сли все монеты были созданы, очищаем список индексов и начинаем сначала
        if (spawnedCoinIndexes.Count >= coinsList.Count)
        {
            spawnedCoinIndexes.Clear();
        }

        return randomIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void Spawn()
    {
        Game.Instance.CurrentCountOfCoins++;
        // ѕровер€ем, что список префабов монет не пустой
        if (coinsList.Count == 0)
        {
            Debug.LogError("Coins List is empty!");

        }    // ѕровер€ем, что список префабов монет не пустой
        if (Game.Instance.CurrentCountOfCoins == Game.Instance.countOfCoins)
        {
            return;

        }

        // √енерируем случайный индекс дл€ выбора монеты из списка
        int randomIndex = GetUniqueRandomIndex();
        if (Game.Instance.CurrentCountOfCoins != Game.Instance.countOfCoins)
        {
            // —оздаем монету на заданной позиции
            GameObject coin = Instantiate(coinsList[randomIndex], spawnPoint.position, Quaternion.identity);
        }


        // ”станавливаем выбранную монету из списка
        //coin.GetComponent<Coin>().CoinCost = coinsList[randomIndex].GetComponent<Coin>().CoinCost;
    }
}
