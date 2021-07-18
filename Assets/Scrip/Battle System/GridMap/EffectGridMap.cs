using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGridMap : MonoBehaviour
{
    [SerializeField] ParticleSystem highLightGrid;
    [SerializeField] ParticleSystem highLight_TileUnder;

    private List<ParticleSystem> highLightMap;
    private ParticleSystem prefeb_highLight_TileUnder;

    public static EffectGridMap instance;

    private void Awake()
    {
        instance = this;
        highLightMap = new List<ParticleSystem>();
        prefeb_highLight_TileUnder = Instantiate(highLight_TileUnder, transform);
    }

    void Start()
    {   
        foreach(Node n in GridManager.instance.nodeTeam1)
        {
            ParticleSystem eff = Instantiate(highLightGrid, transform);
            eff.transform.position = new Vector3(
            n.worldPosition.x,
            n.worldPosition.y,
            n.worldPosition.z);
            highLightMap.Add(eff);
        } 
    }

    public void HighLighMap()
    {
        foreach(ParticleSystem eff in highLightMap)
        {
            eff.Play();
        }
    }

    public void StopHighLighMap()
    {
        foreach (ParticleSystem eff in highLightMap)
        {
            eff.Stop();
        }
    }

    public void HighLight_TileUnder(Vector3 pos)
    {
        prefeb_highLight_TileUnder.transform.position = pos;
        prefeb_highLight_TileUnder.Play();
    }

    public void Stop_HighLight_TileUnder()
    {
        prefeb_highLight_TileUnder.Stop();
    }
}
