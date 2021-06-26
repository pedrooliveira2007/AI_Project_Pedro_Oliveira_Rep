using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private float ExpansionScale = 1f;
    [SerializeField]
    private float _fireLifeTime = 5f;
    private float _actualTime = 0f;


    // Update is called once per frame
    void FixedUpdate()
    {

        if (_actualTime >= _fireLifeTime)
        {
            Debug.Log("destroy fire");
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.transform.localScale += (ExpansionScale * new Vector3(1f, 0, 1f) * Time.fixedDeltaTime);
            _actualTime += Time.fixedDeltaTime;
        }
    }


    internal void StartFire(Vector3 _position, Vector3 _scale)
    {
        this.gameObject.transform.position = _position;
        this.gameObject.transform.localScale = new Vector3(_scale.x, 0.33f, _scale.y);
    }
}