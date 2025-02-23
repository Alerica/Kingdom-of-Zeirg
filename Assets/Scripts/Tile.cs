using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied;
    public Color greenColor;
    public Color redColor;
    private SpriteRenderer buildingImage;
    void Start()
    {   
        buildingImage = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(isOccupied)
        {
            buildingImage.color = redColor;
        }
        else 
        {
            buildingImage.color = greenColor;
        }
    }
}
