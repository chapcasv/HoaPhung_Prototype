using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseEntiny : MonoBehaviour
{

    #region Propreties
    private const int OffsetCellSize = 5; //by cell scale

    public HealthManaBar bar;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public Material mat;
    public GameObject model;
    [SerializeField] Transform spawnEffect;
    public Transform dame_popUpPrefab;


    protected string CardName;
    private CardUnitID cardID;

    #region Stat

    public UnitFaction unitFaction;
    public UnitClass unitClass;
    private int atkDameToLife;
    private int coin;

    public int HP_current;
    public int Base_HP_current;

    public int PhysicReduction = 0;
    public int Base_PhysicReduction = 0;

    public int MagicReduction = 0;
    public int Base_MagicReduction = 0;

    public int HP_max;
    public int Base_HP_max;

    public int SP_regen;
    public int Base_SP_regen;

    public int SP_max;
    public int SP_current;
    public int Base_SP_current;

    public int Str;
    public int Base_Str;

    public int Int;
    public int Base_Int;

    public float Atk_speed;
    public float Base_Atk_speed;

    public float range;
    public float Base_range;

    public float Crit;
    public float Base_Crit;
    public float LifeSteal;
    public float Base_LifeSteal = 0;

    public float movespeed = 1;
    public float Base_movespeed = 1;

    public float Speed_projectile;
    #endregion 

    #region Status
    public bool have_SPbar = true;
    public bool have_StackBar = false;
    public int stack;

    private bool isLive = true;
    public bool IsLive { get => isLive; }

    public bool can_Regen = true;
    public bool canAtk = true;
    public bool can_move = true;
    public bool cc_immune = false;
    public bool slow_immune = false;
    public bool freeze_immune = false;

    #endregion


    public bool canSkil = true;
    public List<BaseEntiny> summon_by_Unit;
    public Unit_Type unitType;

    protected Node curentNode;
    public BaseEntiny currentTarget = null;
    protected bool moving;
    protected Node destination;
    protected Team Myteam;
    protected bool HasEnemy => currentTarget != null;
    protected bool IsInRange => currentTarget != null && currentTarget.isLive && 
        Vector3.Distance(this.transform.position, currentTarget.transform.position) <= range;

    public CardUnitID CardID { get => cardID; set => cardID = value; }
    public int AtkDameToLife { get => atkDameToLife; set => atkDameToLife = value; }
    public Team UnitTeam() { return Myteam; }
    public void SetCurrentNode(Node node) { curentNode = node; }
    public Node GetCurrentNode() { return curentNode; }
    #endregion

    #region Methods



    public void TakeMultiDame(int amount)
    {
        HP_current -= amount;
        bar.SetHP(HP_current);

        float offsetX = Random.Range(-0.3f, 0.3f);
        float offsetY = Random.Range(-0.3f, 0.3f);
        float offsetZ = Random.Range(-0.3f, 0.3f);
        Vector3 posText = transform.position + new Vector3(offsetX, offsetY, offsetZ);
        TextPopUpBattle.CreateUnitTextPopup(amount, posText, dame_popUpPrefab, TextType.Skill,this);
        if (HP_current <= 0)
        {
            isLive = false;
            curentNode.SetOccupied(false);
            BattleSystem.UnitDeath(this);
        }
    }
    public void TakeDamage(int amount, bool isSkill = false)
    {
        HP_current -= amount;
        bar.SetHP(HP_current);

        float offsetX = Random.Range(-0.15f, 0.15f);
        float offsetY = Random.Range(4,6);
        float offsetZ = Random.Range(-0.15f, 0.15f);
        Vector3 posText = transform.position + new Vector3(offsetX, offsetY, offsetZ);

        if (!isSkill)
        {
            TextPopUpBattle.CreateUnitTextPopup(amount, posText, dame_popUpPrefab, TextType.Dame,this);
        }
        else
        {
            TextPopUpBattle.CreateUnitTextPopup(amount, posText, dame_popUpPrefab, TextType.Skill,this);
        }
        

        if (HP_current <= 0)
        {
            isLive = false;
            GainCoin();
            curentNode.SetOccupied(false);
            BattleSystem.UnitDeath(this);
        }
    }

    private void GainCoin()
    {
        if(Myteam == Team.Team2)
        {
            BattleCoin.Add(coin);
            TextPopUpBattle.CreateUnitTextPopup(coin, transform.position, dame_popUpPrefab, TextType.Coin, this);
            BattleUI.instance.UpdateCoinCurrent(BattleCoin.CurrentCoin);
        }
    }

    public void GetHeal(int amount)
    {
        HP_current += amount;
        if(HP_current > HP_max)
        {
            HP_current = HP_max;
        }
        bar.SetHP(HP_current);
        TextPopUpBattle.CreateUnitTextPopup(amount, transform.position, dame_popUpPrefab, TextType.Heal,this);
    }

    public void DescreaseSP(int amount)
    {
        if (!have_SPbar)
            return;

        SP_current -= amount;
        if(SP_current >= 0)
        {
            bar.SetSP(SP_current);
        }
        else
        {
            SP_current = 0;
            bar.SetSP(SP_current);
        }
    }

    
    public void SetUP(Team team, Node spawnNode, Card unit, Unit_Type type_entiny)
    {
        Myteam = team;
        curentNode = spawnNode;
        transform.position = curentNode.worldPosition;
        curentNode.SetOccupied(true);

        meshFilter = unit.mesh;
        mat = unit.mat;

        CardName = unit.CardName;
        CardID = unit.card_UnitID;
        unitClass = unit.unitClass;
        unitFaction = unit.unitFaction;
        AtkDameToLife = unit.AtkDameToLife;
        coin = unit.GoldDrop;

        Base_HP_current = unit.HP;
        HP_current = unit.HP;
        Base_HP_max = unit.HP;
        HP_max = unit.HP;
        PhysicReduction = unit.PhysicReduction;
        Base_PhysicReduction = PhysicReduction;
        MagicReduction = unit.MagicReduction;
        Base_MagicReduction = MagicReduction;


        Base_SP_regen = unit.SPRegen;
        SP_regen = unit.SPRegen;
        Base_SP_current = unit.SPCurrent;
        SP_current = unit.SPCurrent;
        SP_max = unit.SPMax;

        Base_Atk_speed = unit.AtkSpeed;
        Atk_speed = unit.AtkSpeed;

        Base_Str = unit.Str;
        Str = unit.Str;
        Base_Int = unit.Int;
        Int = unit.Int;

        Base_range = GetRanger(unit.Range);
        range = GetRanger(unit.Range);
        Speed_projectile = unit.SpeedProjectile;

        have_SPbar = unit.HaveSPBar;
        have_StackBar = unit.HaveStackBar;

        Base_movespeed = 1f + OffsetCellSize/2;
        movespeed = 1f + OffsetCellSize/2;
        stack = 0;
        unitType = type_entiny;
  
        bar.SetUP(HP_max, SP_max, SP_current, Myteam, have_SPbar, have_StackBar);
        summon_by_Unit = new List<BaseEntiny>();
        SetUP_model();
        //SpawnEffect();
    }

    public void SetUP(Team team, Node spawnNode, BaseEntiny unit, Unit_Type type_entiny)
    {
        Myteam = team;

        this.curentNode = spawnNode;

        transform.position = curentNode.worldPosition;

        curentNode.SetOccupied(true);
        CardName = unit.CardName;
        CardID = unit.CardID;
        unitFaction = unit.unitFaction;
        unitClass = unit.unitClass;

        meshFilter = unit.meshFilter;
        mat = unit.mat;

        HP_current = unit.HP_max;
        Base_HP_current = unit.Base_HP_current;  
        HP_max = unit.HP_max;
        Base_HP_max = unit.Base_HP_max;

        Base_SP_regen = unit.Base_SP_regen;
        SP_regen = unit.SP_regen;
        Base_SP_current = unit.Base_SP_current;
        SP_current = unit.Base_SP_current;
        SP_max = unit.SP_max;

        Base_Atk_speed = unit.Base_Atk_speed;
        Atk_speed = unit.Atk_speed;

        Base_Str = unit.Base_Str;
        Str = unit.Str;

        Base_Int = unit.Base_Int;
        Int = unit.Int;

        Base_range = unit.range;
        range = unit.range;

        Speed_projectile = unit.Speed_projectile;
        have_SPbar = unit.have_SPbar;
        have_StackBar = unit.have_StackBar;

        Base_movespeed = unit.Base_movespeed;
        movespeed = 1f;
        stack = 0;
        unitType = type_entiny;
  
        bar.SetUP(HP_max, SP_max, SP_current, team, have_SPbar, have_StackBar);
        summon_by_Unit = new List<BaseEntiny>();
        SetUP_model();
        //SpawnEffect();
    }
    
    private float GetRanger(int UnitRanger)
    {
        float HorizontalEdgeLength = GridManager.instance.GetHorizontalEdge;
        float DiagonalEdgeLength = GridManager.instance.GetDiagonalEdge;
        float offset = DiagonalEdgeLength - HorizontalEdgeLength;
        float ranger = UnitRanger * HorizontalEdgeLength + offset;
        return ranger;

    }
    private void SetUP_model()
    {
        model.GetComponent<MeshFilter>().sharedMesh = meshFilter.sharedMesh;
        model.GetComponent<MeshRenderer>().material = mat;
        if(Myteam == Team.Team2)
        {
            transform.eulerAngles = new Vector3(-90, 180, 0);
        }
    }

    private void SpawnEffect()
    {
        spawnEffect.GetChild(0).GetComponent<ParticleSystem>().Play();
        spawnEffect.GetChild(1).GetComponent<ParticleSystem>().Play();
    }
   

    protected void FindTarget()
    {
        var allEnemies = BattleSystem.Get_Units_Against(Myteam);

        float minDistance = Mathf.Infinity;
        BaseEntiny candidateTarget = null;
        foreach (BaseEntiny e in allEnemies)
        {
            if(Vector3.Distance(e.transform.position, this.transform.position) <= minDistance)
            {
                minDistance = Vector3.Distance(e.transform.position, this.transform.position);

                candidateTarget = e;
            }
        }
        currentTarget = candidateTarget;  
    }


    public BaseEntiny Find_Far_Target()
    {
        var allEnemies = BattleSystem.Get_Units_Against(Myteam);
        float maxDistance = 0;
        BaseEntiny far_target = null;
        foreach(BaseEntiny e in allEnemies)
        {
            if(Vector3.Distance(transform.position,e.transform.position) > maxDistance){
                maxDistance = Vector3.Distance(transform.position, e.transform.position);
                far_target = e;
            }
        }
        return far_target;
    }

   
    //public void Dash_To_Far_Target()
    //{
    //    var allEnemies = BattleSystem.Get_Units_Against(Myteam);
    //    List<Node> allNode_of_Enemy = new List<Node>();
    //    foreach(BaseEntiny e in allEnemies)
    //    {
    //        allNode_of_Enemy.Add(e.curentNode);
    //    }

    //    currentTarget = Find_Far_Target();

    //    Node dash_to_node = GridManager.instance.Get_Free_Node_forDash(this, currentTarget.curentNode);

    //    curentNode.SetOccupied(false);
    //    Vector3 pos = dash_to_node.worldPosition;
    //    curentNode = dash_to_node;
    //    dash_to_node.SetOccupied(true);
    //    transform.position = pos;
    //    FindTarget();
    //}


    //public BaseEntiny Find_Int_Target()
    //{
    //    var allEnemies = BattleSystem.Get_Units_Against(Myteam);

    //    int maxInt = 0;
    //    BaseEntiny candidateTarget = null;

    //    foreach (BaseEntiny e in allEnemies)
    //    {
    //        if (e.Int >= maxInt)
    //        {
    //            maxInt = e.Int;
    //            candidateTarget = e;
    //        }
    //    }
    //    return candidateTarget;
    //}

    //public void Dash_To_Int_Target()
    //{
    //    currentTarget = Find_Int_Target();
    //    List<Node> close_target = GridManager.instance.GetNodesCloseTo(currentTarget.curentNode);

    //    float maxDistance = 0;
    //    Vector3 dash_to_pos = transform.position;
    //    Node dash_to_node = null;
    //    foreach (Node node in close_target)
    //    {
    //        if (!node.IsOccupided)
    //        {
    //            if (Vector3.Distance(transform.position, node.worldPosition) > maxDistance)
    //            {
    //                dash_to_pos = node.worldPosition;
    //                dash_to_node = node;
    //            }
    //        }
    //    }
    //    curentNode.SetOccupied(false);
    //    curentNode = dash_to_node;
    //    dash_to_node.SetOccupied(true);
    //    transform.position = dash_to_pos;
    //    FindTarget();
    //}

    protected void GetInRange()
    {
        if (currentTarget == null || !currentTarget.isLive)
        {   
            //Set null for target death
            currentTarget = null;
            return;
        }

        if (!moving)
        {
            Node candidateDestination = null;
            List<Node> candidates = GridManager.instance.GetNodesCloseTo(currentTarget.curentNode);

            candidates = candidates.OrderBy(x => Vector3.Distance(x.worldPosition, transform.position)).ToList();

            for (int i = 0; i < candidates.Count; i++)
            {
                if (!candidates[i].IsOccupided)
                {
                    candidateDestination = candidates[i];
                    break;
                }
            }
            if (candidateDestination == null)
                return;
            if (curentNode == null)
                return;
            //Find path to destination

            var path = GridManager.instance.GetPath(curentNode, candidateDestination);
            if (path == null || path.Count <= 1)
                return;

            if (path[1].IsOccupided)
                return;

            //Take ownership of the node
            path[1].SetOccupied(true);
            destination = path[1];
        }

        moving = !MoveTowards(destination);

        if (!moving)
        {
            curentNode.SetOccupied(false);
            SetCurrentNode(destination);
        }
    }

    protected bool MoveTowards(Node nextNode)
    {
        Vector3 direction = nextNode.worldPosition - this.transform.position;
        if(direction.sqrMagnitude <= 0.002f)
        {
            transform.position = nextNode.worldPosition;
            return true;
        }
        transform.position += direction.normalized * movespeed * Time.deltaTime;
        return false;
    }



    protected virtual void Attack()
    {
        if (!canAtk)
        {
            return;
        }

        SP_current += SP_regen;
        bar.SetSP(SP_current);
        float waitBetweenAttack = 1 / Atk_speed;
        StartCoroutine(waitAttackCoroutine(waitBetweenAttack));
    }

    protected virtual void Talent() { }

    protected virtual void Skill() { }

    public void Atk_pas()
    {
        if (!canAtk)
        {
            return;
        }
        

        stack++;
        //bar.SetStack(stack);
        //Skill temp = gameObject.AddComponent<Skill>();
        //temp.GetSkill(CardID, currentTarget, this);

        float waitBetweenAttack = 1 / Atk_speed;
        StartCoroutine(waitAttackCoroutine(waitBetweenAttack));
    }

    IEnumerator waitAttackCoroutine(float waitTime)
    {
        canAtk = false;
        yield return new WaitForSeconds(waitTime);
        canAtk = true;
    }

    #endregion
}


