using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Vector3 angleRotations = new Vector3(0, 100, 0);  

    private void Update()
    {
        transform.Rotate(angleRotations * Time.deltaTime);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            GameManager.Instance.GainCoin(); 
            Destroy(gameObject);  
        }
    }
}
