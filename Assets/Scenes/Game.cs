using Spine.Unity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    //аниматор копилки
    public Animator animator;

    public SkeletonAnimation spine;
    //singletone   
    public static Game Instance;
    //очередь монеток
    public Queue<Coin> Coins;
    //подсчет правильных ответов
    int rigthAnswers = 0;
    //панель  с победой
    public GameObject win;
    //панель  с надписью поробуй ещё
    public GameObject lose;
    //панель  с надписью поробуй ещё
    public GameObject coinPanel;
    //количество попыток
    private int points = 4;
    //Всего монет
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

    //метод для кнопки перезагрузить уровень
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
    //метод для кнопки угадывания монетки cost
    //количество копеек устанавливается в инспекторе
    public void CoinButton(int cost)
    {
        Coin coin = Coins.Dequeue();
        if (coin.CoinCost == cost)
        {
            //добавляем 1 к количеству правильных ответов
            rigthAnswers++;
            Debug.Log($"правильно правильных ответов {rigthAnswers}");
            //уменьшаем на 1 количество попыток 
            points--;
        }
        else
        {
            Debug.Log($"не правильно правильных ответов {rigthAnswers}");
            //уменьшаем на 1 количество попыток 
            points--;
        }
    }
}
