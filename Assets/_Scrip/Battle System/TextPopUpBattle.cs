using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopUpBattle : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    private float moveUpSpeed = 1f;
    private float disappearTime = 0.8f;
    private float disappearSpeed = 1.2f;
    private Color textColor;
    private Transform cam;
    private static BaseEntiny unit_holder;


    private void Awake()
    {
        textMeshPro = transform.GetComponent<TextMeshPro>();
        cam = Camera.main.transform;
    }

    private void Update()
    {   
        if(unit_holder == null)
        {
            //Destroy(gameObject);
        }

        transform.position += new Vector3(0, moveUpSpeed) * Time.deltaTime;

        disappearTime -= Time.deltaTime;
        if(disappearTime <= 0)
        {
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMeshPro.color = textColor;
            if(textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    public static TextPopUpBattle CreateUnitTextPopup(int amount, Vector3 spawnPos, Transform prefab_PopUp, TextType type, BaseEntiny unit)
    {
        Transform damePopUp_Transform = Instantiate(prefab_PopUp, spawnPos, Quaternion.identity);
        TextPopUpBattle damPopUp = damePopUp_Transform.GetComponent<TextPopUpBattle>();
        damPopUp.SetUp(amount, type);
        unit_holder = unit;
        return damPopUp;
    }

    private void SetUp(int amount, TextType type)
    {
        switch (type)
        {
            case TextType.Dame:
                textMeshPro.color = new Color32(255, 111, 52, 255);
                textMeshPro.SetText(amount.ToString());
                break;
            case TextType.Skill:
                SetUpforSkill(amount);
                break;
            case TextType.Heal:
                SetUpforHeal(amount);
                break;
            case TextType.Coin:
                SetUpforCoin(amount);
                break;

        }
        textColor = textMeshPro.color;
    }

    private void SetUpforCoin(int amount)
    {
        textMeshPro.color = Color.yellow;
        textMeshPro.SetText("+" + amount.ToString());
        disappearTime = 1.5f;
        textMeshPro.fontSize = 28f;
    }

    private void SetUpforSkill(int amount)
    {
        textMeshPro.color = new Color32(98, 239, 255, 255);
        textMeshPro.SetText(amount.ToString());
        disappearTime = 1.5f;
        textMeshPro.fontSize = 28f;
    }

    private void SetUpforHeal(int amount)
    {
        textMeshPro.color = new Color32(83, 255, 98, 255);
        textMeshPro.SetText("+" + amount.ToString());
        disappearTime = 1.5f;
        textMeshPro.fontSize = 28f;
    }
}

public enum TextType
{
    Dame,
    Skill,
    Heal,
    Coin
}
