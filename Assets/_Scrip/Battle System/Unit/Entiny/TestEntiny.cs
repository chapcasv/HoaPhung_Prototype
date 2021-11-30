using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEntiny : BaseEntiny
{
    private EffectATK atkEffect;
    private int randomBaseAtk;
    void Update()
    {   
        if(BattleSystem.InBattleMode == false){return;}
        
        //Find new target
        if(!HasEnemy)
        {
            FindTarget(); 
        }

        if(IsInRange && !moving)
        {
            if (canAtk)
            {   
                if(SP_current == SP_max && have_SPbar && canSkil)
                {
                    Skill();
                }
                else if(!have_SPbar && have_StackBar)
                {
                    Atk_pas();
                }
                else if(have_SPbar && have_StackBar)
                {
                    Attack();
                }
                else
                {
                    Attack();
                }
                
            }
        }
        else
        {
            GetInRange();
        }

    }

    protected override void Attack()
    {
        base.Attack();
        
        //Set_Effect_atk(CardID);

        if (currentTarget.IsLive)
        {   
            currentTarget.TakeDamage(RandomBaseAtk(Str));
        }
    }

    private int RandomBaseAtk(int str)
    {
        randomBaseAtk = Random.Range(1, 5);
        randomBaseAtk += str;
        return randomBaseAtk;
    }

    private void Set_Effect_atk(CardUnitID ID)
    {
        atkEffect = CardsData.Get_Effect_Atk_By_ID(ID);
        if(atkEffect != null)
        {
            Transform ef = Instantiate(atkEffect.effect, transform);
            ef.transform.position = transform.GetChild(3).position;
            ef.Find("Projectile").GetComponent<ParticleSystem>().Play();
        }
        
    }
}
