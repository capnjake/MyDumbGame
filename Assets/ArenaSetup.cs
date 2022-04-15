using UnityEngine;

public class ArenaSetup : MonoBehaviour
{
    int xSize = 17;
    int ySize = 9;

    [SerializeField]
    GameObject gridCellObject;

    public GridCell[,] gridCells;

    private void Start()
    {
        gridCells = new GridCell[xSize, ySize];
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        Vector2 gridTopLeft = new Vector2(
            Vector2.zero.x - Mathf.RoundToInt(xSize / 2),
            Vector2.zero.y + Mathf.RoundToInt(ySize / 2)
        );

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                Vector2 cellPlacementLocation = new Vector2(
                    gridTopLeft.x + i, gridTopLeft.y - j);

                GridCell cell = Instantiate(
                    gridCellObject, cellPlacementLocation, Quaternion.identity).GetComponent<GridCell>();

                gridCells[i,j] = cell;
            }
        }
    }
}
