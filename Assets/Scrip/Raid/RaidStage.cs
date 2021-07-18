using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RaidStage 
{
    public string stage_name;
    public string id;
    public string stage_discription;
    public string ID_avatar;
    public List<string> NPC_ID;
    public int maxAmount;
    public List<Battle> battles;

}
