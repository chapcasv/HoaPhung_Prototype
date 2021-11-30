using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragUnit: MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public LayerMask releaseMask;

    [SerializeField] BaseEntiny unit;
    private Vector3 oldPos;
    private bool IsDragging = false;
    private Camera cam;
    private float mZCoord;
    private Vector3 dragOffset;

    void Start()
    {
        cam = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (unit.UnitTeam() == Team.Team2) return;

        EffectGridMap.instance.HighLighMap();

        oldPos = transform.position;
        mZCoord = cam.WorldToScreenPoint(transform.position).z;
        dragOffset = transform.position - GetMouseWorldPos();
        IsDragging = true;
        
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return cam.ScreenToWorldPoint(mousePoint);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsDragging) return;

        transform.position = GetMouseWorldPos() + dragOffset;
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        HighLight_Tile_Under();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
        if (!IsDragging) return;

        if (!TryMove())
        {
            transform.position = oldPos;
        }
        EffectGridMap.instance.StopHighLighMap();
        EffectGridMap.instance.Stop_HighLight_TileUnder();   
    }

    private bool TryMove()
    {
        Tile t = GetTileUnder();
        if (t != null)
        {
            BaseEntiny thisEntity = GetComponent<BaseEntiny>();
            Node candidateNode = GridManager.instance.GetNodeForTile(t);
            if (candidateNode != null && thisEntity != null)
            {
                if (!candidateNode.IsOccupided && candidateNode.index < 32)
                {
                    var currentNode = thisEntity.GetCurrentNode();
                    currentNode.SetOccupied(false);
                    thisEntity.SetCurrentNode(candidateNode);
                    candidateNode.SetOccupied(true);
                    thisEntity.transform.position = candidateNode.worldPosition;

                    return true;
                }
            }
        }
        return false;
    }
    
    public void HighLight_Tile_Under()
    {
        Tile t = GetTileUnder();
        if(t != null) {
            Node candidateNode = GridManager.instance.GetNodeForTile(t);
            if(candidateNode != null)
            {
                EffectGridMap.instance.HighLight_TileUnder(candidateNode.worldPosition);
            }
        }
    }

    public Tile GetTileUnder()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, releaseMask))
        {
            if (hit.collider != null)
            {
                Tile t = hit.collider.GetComponent<Tile>();
                return t;
            }
        }
        return null;
    }


}
