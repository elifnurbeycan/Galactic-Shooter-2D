using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    [SerializeField]
    int bonusId;

    [SerializeField]
    AudioClip audioClip;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (this.transform.position.y < -5.8f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Üçlü atış bonusunu aktifleştir
            Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            if (player_sc != null)
            {
                //bonus ses efekti
                AudioSource.PlayClipAtPoint(audioClip, this.transform.position, 0.85f); 

                switch (bonusId)
                {
                    // 0 Üçlü atış bonus'unu temsil eder
                    case 0:
                        player_sc.TripleShotActive();
                        break;
                    // 1 Hız bonus'unu temsil eder
                    case 1:
                        player_sc.SpeedBonusActive();
                        break;
                    // 2 Kalkan bonus'unu temsil eder
                    case 2:
                        player_sc.ShieldBonusActive();
                        break;
                    default:
                        Debug.Log("Hata Durumu!");
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
