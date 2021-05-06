using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HayMachineControl : MonoBehaviour
{
    public float inputKeyValue;
    public float moveAmount = 1;
    public GameObject hayBalePrefab;
    public float thresholdShoot = 0.5f;
    public Transform haySpawnpoint;
    public GameObject bulletContainer;

    float mesureTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        mesureTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ShootHay();

    }

    void ShootHay()
    {
        if (Input.GetKey(KeyCode.Space) && (Time.time - mesureTime) > thresholdShoot)
        {
            GameObject go = Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
            go.transform.parent = bulletContainer.transform;
            mesureTime = Time.time;
            SoundManager.Instance.PlayShootClip();
        }
    }

    void Move()
    {
        float inputKeyValue = Input.GetAxis("Horizontal");
        Vector3 newPos = transform.position + Vector3.right * moveAmount * inputKeyValue;

        if (newPos.x > -23 && newPos.x < 23)
        {
            transform.Translate(Vector3.right * moveAmount * inputKeyValue);
        }
    }
}
