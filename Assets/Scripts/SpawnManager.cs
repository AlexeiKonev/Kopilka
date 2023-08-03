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

        // ���������, ����� ������ � ����� �������� ��� �� ���� �������
        while (spawnedCoinIndexes.Contains(randomIndex))
        {
            randomIndex = Random.Range(0, coinsList.Count);
        }

        // ��������� ������ � ������ ��� ��������� �����
        spawnedCoinIndexes.Add(randomIndex);

        // ���� ��� ������ ���� �������, ������� ������ �������� � �������� �������
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
        // ���������, ��� ������ �������� ����� �� ������
        if (coinsList.Count == 0)
        {
            Debug.LogError("Coins List is empty!");

        }    // ���������, ��� ������ �������� ����� �� ������
        if (Game.Instance.CurrentCountOfCoins == Game.Instance.countOfCoins)
        {
            return;

        }

        // ���������� ��������� ������ ��� ������ ������ �� ������
        int randomIndex = GetUniqueRandomIndex();
        if (Game.Instance.CurrentCountOfCoins != Game.Instance.countOfCoins)
        {
            // ������� ������ �� �������� �������
            GameObject coin = Instantiate(coinsList[randomIndex], spawnPoint.position, Quaternion.identity);
        }


        // ������������� ��������� ������ �� ������
        //coin.GetComponent<Coin>().CoinCost = coinsList[randomIndex].GetComponent<Coin>().CoinCost;
    }
}
