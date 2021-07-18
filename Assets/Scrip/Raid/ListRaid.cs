using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListRaid : MonoBehaviour
{
    [Header("Raid")]

    [SerializeField] GameObject button_ChosenRaid;
    [SerializeField] Transform listRaid;

    private const string ID_raid_default = "R001";
    private const string Button = "Button";
    private SoundManager sound;
    private Player_Database player_data;
    private Game_Database data;

    #region Info Stage
    [Header("Stage")]

    [SerializeField] Transform listStage;
    [SerializeField] GameObject button_ChosenStage;

    public GameObject infoStage;
    public Text stage_discription;
    public Text stage_name;
    public Image stage_avatar;

    public static RaidStage currentStage;
    #endregion
    private void Awake()
    {
        Load_RaidDataTo_ListRaid();
        Display_stage_to_ListStage(data.list_raid[0]);
        Hiden_info_stage();
    }

   
    private void Load_RaidDataTo_ListRaid()
    {
        data = Save_System.LoadGame();
        GameObject temp;
        foreach(Raid raid in data.list_raid)
        {
            temp = Instantiate(button_ChosenRaid, listRaid);
            temp.transform.Find(Button).Find("Text").GetComponent<Text>().text = raid.Raid_name;
            temp.transform.Find(Button).GetComponent<Button>().onClick.AddListener(delegate ()
            {
                Display_stage_to_ListStage(raid);
            });
        }
        Destroy(button_ChosenRaid);

    }

    public void Display_stage_to_ListStage(Raid raid)
    {  
        GameObject temp;

        //clear old list
        foreach(Transform child in listStage)
        {
            Destroy(child.gameObject);
        }

        foreach(RaidStage stage in raid.raid_stage)
        {   
            temp = Instantiate(button_ChosenStage, listStage);

            temp.transform.Find(Button).Find("Text").GetComponent<Text>().text = stage.stage_name;
            
            temp.transform.Find(Button).GetComponent<Button>().onClick.AddListener(delegate ()
            {
                Show_InfoStage(stage);;
            });
        }
    }

   
    public void Show_InfoStage(RaidStage stage)
    {
        infoStage.SetActive(true);
        stage_discription.text = stage.stage_discription;
        var avatar = DataGraph.Get_Graph_ByID(stage.ID_avatar);
        stage_avatar.sprite = avatar.UnitAvatar;
        currentStage = stage;
;
    }

    public void Battle()
    {
        player_data = Save_System.LoadPlayer();
        Save_System.SaveData(player_data);
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
        sound.PlaySound("fight");
        SceneManager.LoadScene(ListScene.SelectScene.Battle.ToString());
    }

    public void Hiden_info_stage()
    {
        infoStage.SetActive(false);
    }

    public void Back_to_mainMenu()
    {
        SceneManager.LoadScene(ListScene.SelectScene.MainMenu.ToString());
    }
}
