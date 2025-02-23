using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gold = 0;
    public int wood = 0;
    public int food = 0;
    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private TextMeshProUGUI woodText;
    [SerializeField]
    private TextMeshProUGUI foodText;


    private Building buildingToPlace;
    public GameObject grid;
    public CustomCursor customCursor;
    public Tile[] tiles;

    void Update()
    {
        goldText.SetText(gold.ToString());
        woodText.SetText(wood.ToString());
        foodText.SetText(food.ToString());

        if(Input.GetMouseButtonDown(0) && buildingToPlace != null) 
        {
            Tile nearestTile = null;
            float nearestDistance = float.MaxValue;
            foreach(Tile tile in tiles) 
            {
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)); 
                if(distance < nearestDistance)
                {
                    nearestDistance =  distance;
                    nearestTile = tile;
                }
            }

            if(nearestTile.isOccupied == false) 
            {
                Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity);
                buildingToPlace = null;
                nearestTile.isOccupied = true;
                grid.SetActive(false);
                customCursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }

    public void BuyBuilding(Building building)
    {
        if(CanBuy(building)) {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;

            gold -= building.coinCost;
            wood -= building.woodCost;
            food -= building.foodCost;

            buildingToPlace = building;
            grid.SetActive(true);
        }
    }

    public void  AddCoin() 
    {
        gold += 1;
    }

    public void  AddFood() 
    {
        food += 1;
    }

    public void AddWood()
    {
        wood += 1;
    }

    private bool CanBuy(Building building)
    {
        return gold >= building.coinCost && wood >= building.woodCost && food >= building.foodCost;
    }

    
}
