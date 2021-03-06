using UnityEngine;
 /// <summary>
 /// class responsible for escalate the explosions
 /// </summary>
public class Explosion : MonoBehaviour
{
    private float ExpansionScale = 10f;
    [SerializeField]
    private float _explosionLifeTime = 3f;

    private float _actualTime = 0f;
    [SerializeField]
    private Fire _fire;


    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_actualTime >= _explosionLifeTime)
        {
           
            Instantiate(_fire.gameObject, transform.position, new Quaternion());
            _fire.StartFire(transform.position, transform.localScale);
            Destroy(this.gameObject);


        }
        else
        {
            transform.localScale += (ExpansionScale * Vector3.one * Time.fixedDeltaTime);

            _actualTime += Time.fixedDeltaTime;
        }

    }
}



