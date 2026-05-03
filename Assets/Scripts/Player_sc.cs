using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 10;

    float speedMultiplier = 2;

    float nextFire = 0;

    [SerializeField]
    float fireRate = 0.25f;


    [SerializeField]
    GameObject rightEngine, leftEngine;



    [SerializeField]
    bool isSpeedBonusActive = false;

    [SerializeField]
    GameObject laserPrefab;

    [SerializeField]
    GameObject tripleLaserPrefab;

    [SerializeField]
    bool isTripleShotActive = false;

    [SerializeField]
    int lives = 3;

    [SerializeField]
    bool isShieldBonusActive = false;

    [SerializeField]
    GameObject shieldVisualizer;

    [SerializeField]
    int score = 0;

    UIManager_sc uiManager_sc;

    [SerializeField]
    AudioClip laserSoundClip;

    [SerializeField]
    AudioSource audioSource;
    

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        if (shieldVisualizer != null)
            shieldVisualizer.SetActive(false);

        uiManager_sc = GameObject.Find("Canvas").GetComponent<UIManager_sc>();
        if (uiManager_sc == null)
        {
            Debug.LogError("Player_sc :: Start Hata - uiManager_sc NULL değerine sahip!");
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Player_sc :: Start Hata - uiManager_sc NULL değerine sahip!");
        }
        else
        {
            audioSource.clip = laserSoundClip;
        }
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > nextFire))
        {
            nextFire = Time.time + fireRate;
            FireLaser();
        }

    }

    void FireLaser()
    {
        if (!isTripleShotActive)
        {
            Instantiate(laserPrefab,
                    (this.transform.position + new Vector3(0, 1.05f, 0)),
                    Quaternion.identity);
        }
        else
        {
            Instantiate(tripleLaserPrefab,
                    (this.transform.position),
                    Quaternion.identity);
        }
        // Play the laser audio clip
        audioSource.Play();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x,
                                        Mathf.Clamp(transform.position.y, -3.8f, 0),
                                        0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        // Önce kalkan kontrolü
        if (isShieldBonusActive)
        {
            isShieldBonusActive = false;

            if (shieldVisualizer != null)
                shieldVisualizer.SetActive(false);

            return;
        }


        // koruma kalkanı aktif değilse canı bir azalır
        lives--;

        if (lives == 2)
        {
            rightEngine.SetActive(true);
        }
        else if (lives == 1)
        {
            leftEngine.SetActive(true);
        }
        
        if (uiManager_sc != null)
        {
            uiManager_sc.UptadeLives(lives);
        }

        if (lives == 0)
        {
            SpawnManager_sc spawnManager_sc = GameObject
                .Find("Spawn_Manager")
                .GetComponent<SpawnManager_sc>();

            if (spawnManager_sc != null)
            {
                spawnManager_sc.OnPlayerDeath();
            }
            else
            {
                Debug.LogError("Player_sc::Damage spawnManager_sc is NULL");
            }

            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotCancelRoutine());
    }

    public void SpeedBonusActive()
    {
        isSpeedBonusActive = true;
        speed *= speedMultiplier;
        StartCoroutine(SpeedBonusCancelRoutine());
    }

    public void ShieldBonusActive()
    {
        isShieldBonusActive = true;
        if (shieldVisualizer != null)
            shieldVisualizer.SetActive(true);
    }

    IEnumerator TripleShotCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }

    IEnumerator SpeedBonusCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBonusActive = false;
        speed /= speedMultiplier;
    }


    public void AddScore(int points)
    {
        score += points;
        uiManager_sc.UpdateScore(score);
        
    }

 

    //shield için cancel eklenebilir


}
