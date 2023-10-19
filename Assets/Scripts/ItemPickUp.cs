using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public AudioClip clickSound;

    void Pickup()
    {
        if (clickSound != null && ObjectManager.instance.audi != null)
        {
            ObjectManager.instance.audi.PlayOneShot(clickSound);
        }
        Destroy(gameObject);   
        
    }
    public void OnMouseDown()
    {
        if (Time.timeScale == 0)
            return;
        Pickup();
        ObjectManager.instance.currentTotalItems -= 1;
        ObjectManager.instance.Add(item);
        ObjectManager.instance.ListItems();
    }
}
