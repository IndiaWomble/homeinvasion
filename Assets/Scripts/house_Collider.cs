using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house_Collider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision det");
        if (other.name.Equals("Cube"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
