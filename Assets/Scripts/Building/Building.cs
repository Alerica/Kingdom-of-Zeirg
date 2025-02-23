using UnityEngine;

public class Building : MonoBehaviour
{
    public int coinCost;
    public int woodCost;
    public int foodCost;
    public int goldIncrease;
    public int woodIncrease;
    public int foodIncrease;
    public float timeBetweenProduction;
    private float currentTime;

    private GameManager gameManager;

    

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        Debug.Log("Game Manager");
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > timeBetweenProduction) 
        {
            currentTime = 0;
            gameManager.gold += goldIncrease;
            gameManager.wood += woodIncrease;
            gameManager.food += foodIncrease;
        }
    }
}
