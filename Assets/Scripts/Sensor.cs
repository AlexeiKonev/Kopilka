using UnityEngine;

//������ � ������� � 2� ��������
public class Sensor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            //�������� � ������� ������ ���������
            Coin coin = collision.gameObject.GetComponent<Coin>();
            //
            Debug.Log($"������ ��������� {coin.CoinCost} ������");
            //���������� � ������������� � ��������� � ������� ������
            Game.Instance.Coins.Enqueue(coin);
            if(  Game.Instance.CurrentCountOfCoins < Game.Instance.countOfCoins)
            {
                SpawnManager.instance.Spawn();
                
            }
            

        }
    }

}
