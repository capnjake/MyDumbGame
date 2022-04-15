using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    bool isPlacing = false;
    GameObject objToPlace;
    Transform objToPlaceTransform;
    Vector2 mousePositionToWorldRounded;

    public ArenaSetup arena;
    public LayerMask gridMask;

    private void Update()
    {
        if (isPlacing && objToPlaceTransform)
        {
            mousePositionToWorldRounded = new Vector2(
                Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x),
                Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y)
            );

            objToPlaceTransform.position = new Vector2(
                mousePositionToWorldRounded.x,
                mousePositionToWorldRounded.y
            );

            if (Input.GetMouseButtonDown(0))
            {
                // Find cell clicked
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, gridMask);

                if (hit.collider != null)
                {
                    GridCell thisCell = hit.collider.GetComponent<GridCell>();
                    thisCell.BuildOnCell(objToPlace);
                    KillBuild();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                KillBuild();
            }
        }
    }

    public void InitShopPurchase(ShopButton button)
    {
        if (isPlacing) return;

        objToPlace = button.shopObject.gameObject;
        if (objToPlace)
        {
            isPlacing = true;
            objToPlaceTransform = Instantiate(objToPlace, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity).transform;
        }
    }

    private void KillBuild()
    {
        isPlacing = false;
        objToPlace = null;
        if (objToPlaceTransform) GameObject.Destroy(objToPlaceTransform.gameObject);
        objToPlaceTransform = null;
    }
}
