using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_InventoryUI : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
    }

    public void SetActive_inventoryUI()
    {
        gameObject.SetActive(true);
        
    }

    public void Hiden_inventoryUI()
    {
        gameObject.SetActive(false);
    }


}
