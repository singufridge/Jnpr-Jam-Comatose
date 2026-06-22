using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public enum ObjectType
    {
        Solid,
        Squishy,
        Brittle
    }

    [SerializeField] GameManager gameManager;

    [SerializeField] private ObjectType objectType;

    private int maxHP;
    private int currentHP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //change max HP depending on object type, take values from the game manager
        if (objectType == ObjectType.Solid)
        {
            maxHP = gameManager.SolidHP;
        }
        else if (objectType == ObjectType.Squishy)
        {
            maxHP = gameManager.SquishyHP;
        }
        else if (objectType == ObjectType.Brittle)
        {
            maxHP = gameManager.BrittleHP;
        }

        Debug.Log(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name == "Player")
        {
            
        }
    }
}
