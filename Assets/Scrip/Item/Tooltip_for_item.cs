using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip_for_item: MonoBehaviour
{   
    [SerializeField]
    private Camera uicamera;

    [SerializeField]
    RectTransform canvas_rectTransform;

    public static Tooltip_for_item instance;

    Transform tooltip;
    Image icon;
    Text Item_name;
    Text opt1_discription;
    Text opt2_discription;
    Text opt3_discription;
    RectTransform bg_rectTransform;
    

    Vector2 localPoint;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);   
        }
        else
        {
            Destroy(gameObject);          
        }

        tooltip = transform.GetChild(0);
        bg_rectTransform = tooltip.GetComponent<RectTransform>();
        canvas_rectTransform = transform.GetComponent<RectTransform>();
        icon = tooltip.Find("Icon").GetComponent<Image>();
        Item_name = tooltip.Find("Name").GetComponent<Text>();
        opt1_discription = tooltip.Find("Opt1").GetComponent<Text>();
        opt2_discription = tooltip.Find("Opt2").GetComponent<Text>();
        opt3_discription = tooltip.Find("Opt3").GetComponent<Text>();
        hiden_tooltip();

    }
    private void Update()
    { 
        Tooptip_flow_mouse_poisiton();
    }

    void Tooptip_flow_mouse_poisiton()
    {
        //+ (Item_name.preferredWidth)
        Vector3 set_mouse_poisition = new Vector3(Input.mousePosition.x + (Item_name.preferredWidth), Input.mousePosition.y +120f);
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponent<RectTransform>(),
        //    set_mouse_poisition, uicamera, out localPoint);
        //tooltip.localPosition = localPoint;

        bg_rectTransform.anchoredPosition = set_mouse_poisition /canvas_rectTransform.localScale.x;
 
    }
    void show_tooltip(Sprite Icon,string name, string opt1, string opt2 = null, string opt3=null)
    {
        icon.sprite = Icon;
        Item_name.text = name;
        opt1_discription.text = opt1;
        opt2_discription.text = opt2;
        opt3_discription.text = opt3;

        Vector2 bg_size = new Vector2(Item_name.preferredWidth + 120f, bg_rectTransform.sizeDelta.y);
        bg_rectTransform.sizeDelta = bg_size;

        gameObject.SetActive(true);

    }

    void hiden_tooltip()
    {
        gameObject.SetActive(false);
    }

    public static void Show_tooltip(Sprite Icon, string name, string opt1, string opt2 = null, string opt3 = null)
    {
        instance.show_tooltip(Icon, name, opt1, opt2, opt3);
    }

    public static void Hiden_tooltip()
    {
        instance.hiden_tooltip();
    }
}
