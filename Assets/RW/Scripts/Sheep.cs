using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    public float dropDestroyDelay;

    public float heartOffset; //Y axis where the heart will spawn
    public GameObject heartPrefab;

    private bool hitByHay;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    private SheepSpawner sheepSpawner;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }
    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true; 
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);

        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity, gameObject.transform.parent);

        TweenScale tweenScale = gameObject.AddComponent<TweenScale>(); ;
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = gotHayDestroyDelay;

        SoundManager.Instance.PlaySheepHitClip();

        GameStateManager.Instance.SavedSheep();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ontriggeron");
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay(); 
        }
        else if (other.CompareTag("DropSheep"))
        {            
            Drop();
        }
    }

    private void Drop()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);

        SoundManager.Instance.PlaySheepDroppedClip();
        Debug.Log("Drop()");
        GameStateManager.Instance.DroppedSheep();
    }

    public void SetSpawner(SheepSpawner spawner)
    {        
        sheepSpawner = spawner;
    }
}
