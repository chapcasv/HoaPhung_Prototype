using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Text_popUP_manager : MonoBehaviour
{
    float moveUp_Speed = 30f;
    float disappearTimer = 1.2f;
    Color textColor;
    TextMeshProUGUI textMesh;
    
    private void Start()
    {
        textMesh = transform.GetComponent<TextMeshProUGUI>();
        textColor = textMesh.color;
        transform.position += new Vector3(0, 300);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, moveUp_Speed) * Time.deltaTime;
        transform.localScale += new Vector3(0.1f, 0.05f) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            float Disappear_Speed = 1.2f;
            textColor.a -= Disappear_Speed* Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
