using UnityEngine;
using System.Collections;
public class CameraShake : MonoBehaviour
{

    private Vector3 originPosition;

    private Quaternion originRotation;

    public float shake_decay;

    public float shake_intensity;

   public bool shaking;

    private Transform _transform;

    public GameObject gameObject;

    void OnGUI()
    {

        //if (GUI.Button(new Rect(20, 40, 80, 20), "Shake"))
        //{

        //    Shake();

        //}

    }

    void OnEnable()
    {

        _transform = transform;

    }

    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {

        if (!shaking)

            return;

        if (shake_intensity > 0f)
        {

            _transform.localPosition = originPosition + Random.insideUnitSphere * shake_intensity;

            _transform.localRotation = new Quaternion(

            originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,

            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,

            originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,

            originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f);

            shake_intensity -= shake_decay;

        }
        else
        {

            //Debug.Log("stopped shaking");

            shaking = false;

            gameObject.SetActive(false);

            _transform.localPosition = originPosition;

            _transform.localRotation = originRotation;

        }

    }

    public void Shake()
    {

        if (!shaking)
        {

            originPosition = _transform.localPosition;

            originRotation = _transform.localRotation;

        }

        shaking = true;

        gameObject.SetActive(true);

        shake_intensity = .1f;

        shake_decay = 0.002f;

    }

}