using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMountainEntiny : BaseEntiny
{   
    void Update()
    {

        //Need Observer
        if (BattleSystem.InBattleMode == false) { return; }

        //Find new target
        if (!HasEnemy)
        {
            FindTarget();
        }

        if (IsInRange && !moving)
        {
            if (canAtk)
            {
                if (SP_current == SP_max && have_SPbar && canSkil)
                {
                    Skill();
                }
                else if (!have_SPbar && have_StackBar)
                {
                    Atk_pas();
                }
                else if (have_SPbar && have_StackBar)
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
}
