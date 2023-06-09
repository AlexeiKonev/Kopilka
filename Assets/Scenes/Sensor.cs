using UnityEngine;

//крепим к обьекту с 2д тригером
public class Sensor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            //получаем у упавшей монеты компонент
            Coin coin = collision.gameObject.GetComponent<Coin>();
            //
            Debug.Log($"монета номиналом {coin.CoinCost} копеек");
            //обращаемся к геймменеджеру и вписываем в очередь монету
            Game.Instance.Coins.Enqueue(coin);
            if(  Game.Instance.CurrentCountOfCoins < Game.Instance.countOfCoins)
            {
                SpawnManager.instance.Spawn();
                
            }
            

        }
    }

}
