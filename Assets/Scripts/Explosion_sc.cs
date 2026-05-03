using UnityEngine;

public class Explosion_sc : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, 2.4f);
    }


}
