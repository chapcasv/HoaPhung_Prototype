using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BattleUI : Manager<BattleUI>
{
    #region Properties

    public List<Card> playerDeck = new List<Card>();

    [Header("Time Bar")]
    [SerializeField] TimeBar timeBar;

    [Header("Synergy UI")]
    [SerializeField] SynergyUI synergyUI;

    [Header("Card hand UI")]
    [SerializeField] CardHandUI cardHandUI;

    [Header("Confirm Start Phase")]
    [SerializeField] GameObject B_Confirm;

    [Header("Battle Infomation")]
    [SerializeField] GameObject teamInfo;
    [SerializeField] TextMeshProUGUI textUnitAmount;
    [SerializeField] TextMeshProUGUI textBattleCoin;
    [SerializeField] TextMeshProUGUI textBattleHP;

    [Header("Wave Count")]
    [SerializeField] GameObject waveCount;
    private TextMeshProUGUI waveCountText;
    private int maxWave;
    private int currentWave;

    [Header("Enemy Life")]
    [SerializeField] TextMeshProUGUI enemyLifeText;

    [Header("Warring PopUp")]
    [SerializeField] Transform warringPopUpUi_transform;
    private bool activeWarringUI = false;
    private float moveUpSpeed = 0.7f;
    private float disappearTime = 2f;
    private float fadeSpeed = 2f;
    private Color warringTextColor;
    private Vector3 originalPos_warringUI;
    private TextMeshProUGUI warringTMP;

    [Header("Dialog Win/Lose")]
    [SerializeField] GameObject WinLosePopUp;
    [SerializeField] TextMeshProUGUI result;

    private readonly Color32 textHighLight = new Color32(0, 255, 255, 255);
    private const string resultWin = "Victory";
    private const string resultLose = "Lose";
    private const string warringPopUp_text = "Lượng tướng vượt quá Quân Lực cho phép";

    #endregion

    #region Methods
    void Start()
    {
        HidenDialog();
        warringPopUpUi_transform.gameObject.SetActive(false);
        Phase_StartCardHand();
        synergyUI.SetUp();
        //UpdateUnitAmount(0);
    }



    private void Update()
    {
        WarringPopUp_Fade();
    }

    private void Phase_StartCardHand()
    {
        BattleSystem.InBattleMode = false;
        BattleSystem.InStartPhase = true;
        UpdateStartUI();
        cardHandUI.Load();
        timeBar.StartPhase();
    }

    public void DrawPhase()
    {
        BattleSystem.InDrawPhase = true;
        UpdateWaveCountCurrent();
        cardHandUI.DrawPhase();
    }

    public void Fight()
    {
        if (UnitInLimited())
        {
            CloneBattleSystem.Save_UnitPos();
            BattleSystem.InDrawPhase = false;
            BattleSystem.InBattleMode = true;
            timeBar.BattlePhase();
        }
        else { CreateWarringPopUp(); }
    }

    public void Confirm()
    {
        BattleSystem.InStartPhase = !BattleSystem.InStartPhase;
        BattleSystem.InDrawPhase = true;
        timeBar.DrawPhase();
        cardHandUI.ChangeToDrawPhase();
        teamInfo.SetActive(true);
        B_Confirm.SetActive(false);
    }

    private bool UnitInLimited()
    {
        if (BattleSystem.CurrentUnitAmount() <= BattleSystem.maxUnit) return true;
        else return false;
    }

    private void UpdateStartUI()
    {
        //When start player dont have unit in board
        UpdateMemberCurrent(0);
        IniWaveCount();
        IniEnemyLife();
        UpdateCoinCurrent(BattleCoin.GetStartCoin());
        UpdateLifeCurrent(BattlePlayerLife.GetStartLife());
    }

    private void IniEnemyLife()
    {
        enemyLifeText.text = RaidManager.currentRaid.EnemyLife.ToString();
    }

    private void IniWaveCount()
    {
        maxWave = RaidManager.currentRaid.ListWave.Count;
        currentWave = 1;
        waveCountText = waveCount.transform.GetComponent<TextMeshProUGUI>();
        waveCountText.text = currentWave + "/" + maxWave;
    }

    public void UpdateUICurrent()
    {   
        UpdateMemberCurrent(BattleSystem.CurrentUnitAmount());
        UpdateCoinCurrent(BattleCoin.CurrentCoin);
        UpdateLifeCurrent(BattlePlayerLife.CurrentLife);
    }

    private void UpdateWaveCountCurrent()
    {
        currentWave += 1;
        if(currentWave <= maxWave)  { waveCountText.text = currentWave + "/" + maxWave;}
    }

    public void UpdateEnemyLifeCurrent(int enemyLife)
    {
        enemyLifeText.text = enemyLife.ToString();
    }

    public void UpdateCoinCurrent(int coin)
    {
        textBattleCoin.text = coin.ToString();
    }

    private void UpdateLifeCurrent(int life)
    {
        textBattleHP.text = life.ToString();
    }

    public void UpdateMemberCurrent(int Amount)
    {   
        //We dont need to update went fight
        if (!BattleSystem.InBattleMode)
        {
            textUnitAmount.text = Amount + "/" + BattleSystem.maxUnit;
            SetColorMemberAmout(Amount);
        }  
    }
    
    private void SetColorMemberAmout(int Amount)
    {
        if(Amount < BattleSystem.maxUnit)
        {
            textUnitAmount.color = textHighLight;
        }
        else if( Amount == BattleSystem.maxUnit)
        {
            textUnitAmount.color = Color.white;
        }
        else if( Amount > BattleSystem.maxUnit)
        {
            textUnitAmount.color = Color.red;
        }
    }

    public void RemoveCardInHand(Card card, Transform slot)
    {
        cardHandUI.RemoveCard(card,slot);
    }

    private void CreateWarringPopUp()
    {
        if (!activeWarringUI)
        {
            warringTMP = warringPopUpUi_transform.GetComponent<TextMeshProUGUI>();
            originalPos_warringUI = warringPopUpUi_transform.position;
            warringTMP.SetText(warringPopUp_text);
            warringTextColor = warringTMP.color;
            warringPopUpUi_transform.gameObject.SetActive(true);
            activeWarringUI = true;
        }   
    }

    private void WarringPopUp_Fade()
    {
        if (!activeWarringUI)
        {
            return;
        }
        else
        {
            disappearTime -= Time.deltaTime;
            if(disappearTime <= 0)
            {
                warringPopUpUi_transform.position += new Vector3(0, moveUpSpeed) * Time.deltaTime;
                warringTextColor.a -= fadeSpeed * Time.deltaTime;
                warringTMP.color = warringTextColor;

                if(warringTextColor.a <= 0)
                {
                    ResetWarringPopUp();
                }
            }
        }
    }

    private void ResetWarringPopUp()
    {
        activeWarringUI = false;
        disappearTime = 2f;
        warringTextColor.a = 1;
        warringTMP.color = warringTextColor;
        warringPopUpUi_transform.position = originalPos_warringUI;
        warringPopUpUi_transform.gameObject.SetActive(false);
    }

    public void Show_Dialog(bool win)
    {
        if (win)
        {
            result.text = resultWin;
        }
        else if(!win)
        {
            result.text = resultLose;
        }
        WinLosePopUp.SetActive(true);
    }

    private void HidenDialog()
    {
        WinLosePopUp.SetActive(false);
    }

    public void Set_synergyUIGodDragon()
    {
        synergyUI.F_GodDragon_UI();
    }

    public void Set_synergyUIBeast()
    {
        synergyUI.F_Beast_UI();
    }

    public void Set_synergyUIWater()
    {
        synergyUI.Water_UI();
    }

    public void Set_synergyUIRockMountain()
    {
        synergyUI.RockMountain_UI();
    }

    public void Set_synergyUIHunter()
    {
        synergyUI.Hunter_UI();
    }

    public void Set_synergyUIWarrior()
    {
        synergyUI.Warrior_UI();
    }

    public void Set_synergyUICavalry()
    {
        synergyUI.Cavalry_UI();
    }

    //private void MoveUnit(PlayerCard hero)
    //{

    //    if (!Unit_Is_onGrid(hero))
    //    {
    //        //AddToGrid(hero);
    //    } 
    //}


    //private void AddToGrid(Card card)
    //{
    //    var unitGraph = DataGraphic.Get_AvatarCard(card);
    //    BattleSystem.instance.AddUnit_For(Team.Team1, hero, unitGraph,Unit_Type.Hero);
    //}







    #endregion

}
