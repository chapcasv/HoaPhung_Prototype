using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : BaseEntiny
{
    private bool isSkill = true;

    private int HP_base;
    private int Shield_bonus;
    private int dam;
    private int regen;
    private EffectSkill skillEffect;

    public void GetSkill(string id, BaseEntiny target, BaseEntiny unit_use_Skill)
    {
        switch (id)
        {
            case "H001":
                H001_BangDuc(target, unit_use_Skill);
                break;
            case "H002":
                H002_LyNho(unit_use_Skill);
                break;
            case "H003":
                H003_TruongPhi(unit_use_Skill);
                break;
            case "H004":
                H004_DongTrac(unit_use_Skill);
                break;
            case "H005":
                H005_HoaHung(unit_use_Skill);
                break;
            case "H007":
                H007_GiaHu(unit_use_Skill);
                break;
            case "H008":
                H008_LuBo(unit_use_Skill);
                break;
            case "H010":
                H010_DiemHanh(unit_use_Skill);
                break;
            case "H011":
                H011_LuuBi(unit_use_Skill);
                break;
            case "H009":
                H009_QuanVu(unit_use_Skill);
                break;
            case "H073":
                H073_MaSieu(unit_use_Skill);
                break;
            case "H090":
                H090_TranDao_Summon(unit_use_Skill);
                break;
            default:
                break;

        }
    }

    private void H073_MaSieu(BaseEntiny unit_use_skill)
    {
        HP_base = unit_use_skill.HP_max;
        Shield_bonus = 0;
        dam = 0;

        if (unit_use_skill.level < 5)
        {
            dam = 100;
            Shield_bonus = (HP_base * 30) / 100;
        }
        else if (5 <= unit_use_skill.level && unit_use_skill.level < 10)
        {
            dam = 200;
            Shield_bonus = (HP_base * 35) / 100;
        }
        else if (unit_use_skill.level == 10)
        {
            dam = 300;
            Shield_bonus = (HP_base * 50) / 100;
        }

    }

    //Melee skill
    //Effect on weapon
    private void H001_BangDuc(BaseEntiny current, BaseEntiny unit_use_skill)
    {

        dam = 0;
        regen = 0;

        currentTarget = current;
        if(unit_use_skill.level < 5)
        {
            dam = (unit_use_skill.Str * 260) / 100;
            regen = 200;
        }
        else if(5 <= unit_use_skill.level && unit_use_skill.level < 10)
        {
            dam = (unit_use_skill.Str * 290) / 100;
            regen = 300;
        }
        else if (unit_use_skill.level == 10)
        {
            dam = (unit_use_skill.Str * 360) / 100;
            regen = 450;
        }

        currentTarget.TakeDamage(dam,isSkill);

        unit_use_skill.GetHeal(regen);
    }


    // Range skill
    // Dame Target
    // Create shield team mate

    private void H002_LyNho(BaseEntiny unit_use_skill)
    {
        int dam_byHP = (unit_use_skill.currentTarget.HP_max / 100) % 4;
        int dam_byInt = (unit_use_skill.Int * 120) / 100;
        int dame = dam_byInt + dam_byHP;
        unit_use_skill.currentTarget.TakeDamage(dame,isSkill);
        Debug.Log("Ly Nho dame: " + dame);
        unit_use_skill.currentTarget.can_Regen = false;

    }

    //Create shield reduction dame
    //Melee dame direction
    //Regen HP
    private void H003_TruongPhi(BaseEntiny unit_use_skill)
    {
        unit_use_skill.Dash_To_Far_Target();
        int dame = unit_use_skill.Int;
        unit_use_skill.currentTarget.TakeDamage(dame);
        Debug.Log("Truong Phi skill");
    }

    private void H004_DongTrac(BaseEntiny unit_use_skill)
    {
        dam = 0;
        regen = 0;

        if (unit_use_skill.level < 5)
        {
            dam = (unit_use_skill.Int * 260) / 100;

        }
        unit_use_skill.currentTarget.TakeDamage(dam, isSkill);
        Set_Effect_Skill(unit_use_skill.Unit_ID, unit_use_skill.currentTarget.curentNode.worldPosition);
        Debug.Log("Dong Trac skill");
    }
    private void H005_HoaHung(BaseEntiny unit_use_skill)
    {
        unit_use_skill.Dash_To_Far_Target();
        int dame = unit_use_skill.Str;
        unit_use_skill.currentTarget.TakeDamage(dame + 50);
        unit_use_skill.GetHeal(200);
        Debug.Log("Hoa Hung skill");

    }
    private void H006_CaoThuan(BaseEntiny unit_use_skill)
    {
        unit_use_skill.Dash_To_Int_Target();
        int dame = unit_use_skill.Int;
        unit_use_skill.currentTarget.DescreaseSP(dame);
        //Talent;
        Debug.Log("Cao Thuan skill");
    }

    private void H007_GiaHu(BaseEntiny unit_use_skill)
    {
        unit_use_skill.Dash_To_Int_Target();
        int dame = unit_use_skill.Int;
        unit_use_skill.currentTarget.DescreaseSP(dame);
        //Talent;
        Debug.Log("Cao Thuan skill");
    }

    private void H008_ChuThai(BaseEntiny current,BaseEntiny unit_use_skill)
    {
        unit_use_skill.bar.SetStack(unit_use_skill.stack);
        currentTarget = current;
        int dame_chu_thai = (unit_use_skill.HP_max / 100) * 5;
        //Debug.Log("Dame " + dame_chu_thai);
        currentTarget.TakeDamage(dame_chu_thai);
        //Debug.Log("Stack " + unit_use_skill.stack);

        if (unit_use_skill.stack == 5 && unit_use_skill.can_Regen)
        {

            int regen_by_HP_max = (unit_use_skill.HP_max / 100) * 8;
            unit_use_skill.HP_current += regen_by_HP_max;
            unit_use_skill.bar.SetHP(unit_use_skill.HP_current);
            unit_use_skill.stack = 0;
            unit_use_skill.bar.SetStack(0);

            //Debug.Log("Regen " + regen_by_HP_max);
        }
     
    }

    private void H008_LuBo(BaseEntiny unit_use_skill)
    {

    }

    private void H009_QuanVu(BaseEntiny unit_use_skill)
    {
        StartCoroutine(QuanVuSpin(unit_use_skill));
    }

    private void H010_DiemHanh(BaseEntiny unit_use_skill)
    {
        dam = 0;

        if (unit_use_skill.level < 5)
        {
            dam = (unit_use_skill.Str * 120) / 100;
        }
        else if (5 <= unit_use_skill.level && unit_use_skill.level < 10)
        {
            dam = (unit_use_skill.Str * 140) / 100;

        }
        else if (unit_use_skill.level == 10)
        {
            dam = (unit_use_skill.Str * 180) / 100;
        }

        for (int i = 0; i < 3; i++)
        {
            unit_use_skill.canAtk = false;
            dam += UnityEngine.Random.Range(1, 5);
            unit_use_skill.currentTarget.TakeMultiDame(dam);
        }
        unit_use_skill.canAtk = true;
        Debug.Log("Diem hanh Dame " + dam);

    }

  

    
    private void H011_LuuBi(BaseEntiny unit_use_Skill)
    {   
        if(unit_use_Skill.stack < 4)
        {
            unit_use_Skill.stack += 1;
            unit_use_Skill.bar.SetStack(unit_use_Skill.stack);
            BaseEntiny trandao = Instantiate(BattleSystem.instance.allEntitiesPrefab[1]);
            unit_use_Skill.summon_by_Unit.Add(trandao);
            trandao.SetUP(
                unit_use_Skill.UnitTeam(),
                GridManager.instance.GetFreeNode(unit_use_Skill.UnitTeam()),
                trandao,
                Unit_Type.Summon);
        }
        else
        {
            // bien Han trung vuong
        } 
    }
    
    IEnumerator QuanVuSpin(BaseEntiny unit_use_skill)
    {
        unit_use_skill.canSkil = false;
        int spin = 1;
        for (int i = 0; i < 3; i++)
        {
            List<Node> rangeSpin = GridManager.instance.GetNodesCloseTo(unit_use_skill.curentNode);
            List<BaseEntiny> allenemy = BattleSystem.instance.Get_Units_Against(unit_use_skill.UnitTeam());
            List<BaseEntiny> enemy_Will_takeDam = new List<BaseEntiny>();

            int dam_spin = (unit_use_skill.Str * 110) / 100;

            //create buff
            foreach (BaseEntiny e in allenemy)
            {
                foreach (Node n in rangeSpin)
                {
                    if (e.curentNode == n)
                    {
                        enemy_Will_takeDam.Add(e);
                    }
                }
            }
            foreach (BaseEntiny e in enemy_Will_takeDam)
            {
                e.TakeDamage(dam_spin);
            }

            Debug.Log(dam_spin);
            Debug.Log(spin);
            spin++;
            yield return new WaitForSeconds(1);
        }
        unit_use_skill.canSkil = true;
    }

    private void H090_TranDao_Summon(BaseEntiny unit_use_skill)
    {
        unit_use_skill.bar.SetStack(unit_use_skill.stack);
        int dame_trandao = unit_use_skill.Str;
        Debug.Log("Dame " + dame_trandao);
        unit_use_skill.currentTarget.TakeDamage(dame_trandao);
        Debug.Log("Stack " + unit_use_skill.stack);

        if (unit_use_skill.stack == 5)
        {
            Debug.Log("5 stack");
        }
    }

    private void Set_Effect_Skill(string ID, Vector3 pos)
    {
        skillEffect = DataGraph.Get_Effect_Skill_By_ID(ID);
        if (skillEffect != null)
        {
            Transform ef = Instantiate(skillEffect.effect, transform);
            ef.transform.position = pos;
            ef.GetComponent<ParticleSystem>().Play();
        }

    }


}
