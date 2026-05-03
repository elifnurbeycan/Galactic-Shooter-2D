using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    int speed = 4;

    Player_sc player_sc;
    Animator animator;

    AudioSource audioSource;

    void Start()
    {
        // Player'ı bul ve scriptini al
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj != null)
        {
            player_sc = playerObj.GetComponent<Player_sc>();
        }

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Aşağı doğru hareket
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Ekranın altına inince yok olsun (SpawnManager yenisini üretiyor)
        if (this.transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Durum: OYUNCU İLE ÇARPIŞMA
        if (other.tag == "Player")
        {
            // Player scriptine eriş ve hasar ver
            if (player_sc != null)
            {
                player_sc.Damage();
            }

            // Animasyonu Tetikle
            animator.SetTrigger("OnEnemyDeath");

            // Hızı Sıfırla (Olduğu yerde patlasın)
            speed = 0;
            //patlama sesini çal
            audioSource.Play();

            //Patlarken tekrar hasar vermemesi için çarpışmayı kapat
            GetComponent<Collider2D>().enabled = false;

            // Gecikmeli Yok Etme
            Destroy(this.gameObject, 2.6f);
        }

        // 2. Durum: LAZER İLE ÇARPIŞMA
        else if (other.tag == "Laser")
        {
            // Lazeri hemen yok et
            Destroy(other.gameObject);

            // Puan Ekle
            if (player_sc != null)
            {
                player_sc.AddScore(10);
            }

            // Animasyonu Tetikle
            animator.SetTrigger("OnEnemyDeath");

            // Hızı Sıfırla
            speed = 0;

            audioSource.Play();

            //Patlarken başka lazerler çarpmasın diye collider'ı kapat
            GetComponent<Collider2D>().enabled = false;

            //Animasyon bitene kadar bekle (2.6 sn)
            Destroy(this.gameObject, 2.6f); 
        }
    }
}