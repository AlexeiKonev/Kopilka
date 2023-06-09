using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    //singletone   
    public static Game Instance;
    //������� �������
    public Queue<Coin> Coins ;
    //������� ���������� �������
    int rigthAnswers = 0;
    //������  � �������
    public GameObject win;
    //������  � �������� ������� ���
    public GameObject lose;
    //���������� �������
    private int points = 4;
    //����� �����
    public int countOfCoins = 4;
    public int CurrentCountOfCoins = 0;
    

    void Start()
    {
        Coins = new Queue<Coin>();
        win.SetActive(false);
        lose.SetActive(false);

        if (Instance == null)
        {
            Instance = this;
        }

    }

     
    void Update()
    {
        if (rigthAnswers >= countOfCoins)
        {
            win.SetActive(true);
        }
        if (rigthAnswers < countOfCoins && points == 0)
        {
            lose.SetActive(true);
        }
    }

    //����� ��� ������ ������������� �������
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
    //����� ��� ������ ���������� ������� cost
    //���������� ������ ��������������� � ����������
    public void CoinButton(int cost)
    {
        Coin coin = Coins.Dequeue();
        if (coin.CoinCost == cost)
        {
            //��������� 1 � ���������� ���������� �������
            rigthAnswers++;
            Debug.Log($"��������� ���������� ������� {rigthAnswers}");
            //��������� �� 1 ���������� ������� 
            points--;
        }
        else
        {
            Debug.Log($"�� ��������� ���������� ������� {rigthAnswers}");
            //��������� �� 1 ���������� ������� 
            points--;
        }
    }
}
