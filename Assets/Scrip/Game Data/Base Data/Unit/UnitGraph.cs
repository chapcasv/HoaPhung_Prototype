using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Graphic", menuName = "Game Data/Unit Graph")]

public class UnitGraph : ScriptableObject
{

    public MeshFilter UnitFilter;
    public MeshRenderer UnitRenderer;
    public Material UnitMat;
    public Sprite UnitAvatar;
    public string UnitID;

}
