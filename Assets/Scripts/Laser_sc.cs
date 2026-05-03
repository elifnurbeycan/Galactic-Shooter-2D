using UnityEngine;

public class Laser_sc : MonoBehaviour
{
    [SerializeField]
    private int speed = 3;
    
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (this.transform.position.y > 7)
        {
            if (this.transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
