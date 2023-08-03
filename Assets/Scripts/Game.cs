using Spine.Unity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    //�������� �������
    public Animator animator;

    public SkeletonAnimation spine;
    //singletone   
    public static Game Instance;
    //������� �������
    public Queue<Coin> Coins;
    //������� ���������� �������
    int rigthAnswers = 0;
    //������  � �������
    public GameObject win;
    //������  � �������� ������� ���
    public GameObject lose;
    //������  � �������� ������� ���
    public GameObject coinPanel;
    //���������� �������
    private int points = 4;
    //����� �����
    public int countOfCoins = 4;
    public int CurrentCountOfCoins = 0;
    bool shaked = false;
    //SkeletonAnimation skeletonAnimation;
    //Spine.AnimationState animationState;
    //animationState.SetAnimation(trackIndex, "walk", true);


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
        if (CurrentCountOfCoins == countOfCoins && !shaked)
        {
            animator.SetTrigger("PigIsFull");

            coinPanel.SetActive(true);
            shaked = true;
        }
        if (rigthAnswers >= countOfCoins)
        {
            spine.AnimationName = "win";
            win.SetActive(true);
        }
        if (rigthAnswers < countOfCoins && points <= 0)
        {
            spine.AnimationName = "wrong";
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
