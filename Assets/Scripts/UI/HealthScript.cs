using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour 
{
    public RectTransform healthTransform;
    private float positionY;
    private float minX;
    private float maxX;
    private int currentHP;
    public float speed; //this value was just for the testing, not important to actual healthbar code

    private int CurrentHP
    {
        get { return currentHP; }
        set { 
            currentHP = value;
            HealthUpdate();
        }
    }
    public int maxHP;
    public Image healthBar;
    public float coolDown;  //this value controls how often damage can occur
    public bool onCD;

	// Use this for initialization
	void Start () 
    {
        positionY = healthTransform.position.y;
        maxX = healthTransform.position.x;
        minX = healthTransform.position.x - healthTransform.rect.width;
        currentHP = maxHP;
        onCD = false;
	}

    //controls the cooldown period between taking damage
    IEnumerator DmgCD()
    {
        onCD = true;
        yield return new WaitForSeconds(coolDown);
        onCD = false;
    }
	
	// Update is called once per frame
	void Update () 
    {
        HandleMovement();
	
	}
    private void HealthUpdate()
    {
        float currentX = MapValues(currentHP, 0, maxHP, minX, maxX);

        healthTransform.position = new Vector3(currentX, positionY);

        //this segment is what controls the change of color as health decreases
        if (currentHP > maxHP/2)
        {
            healthBar.color = new Color32((byte)MapValues(currentHP, maxHP / 2, maxHP, 255, 0), 255, 0, 255);
        }
        else
        {
            healthBar.color = new Color32(255, (byte)MapValues(currentHP, 0, maxHP / 2, 0, 255), 0, 255);
        }
    }
    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    //This portion was just to test it out, not that important
    private void HandleMovement()
    {
        float translation = speed * Time.deltaTime;

        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * translation, 0, Input.GetAxis("Vertical") * translation));
    }
    void OnTriggerStay(Collider other)
    {
        if (other.name == "Health")
        {
            if (!onCD && currentHP < maxHP)
            {
                StartCoroutine(DmgCD());
                CurrentHP += 1;
            }
            Debug.Log("Getting healed");
        }
        if (other.name == "Damage")
        {
            if (!onCD && currentHP > 0)
            {
                StartCoroutine(DmgCD());
                CurrentHP -= 1;
            }
            Debug.Log("Taking damage");
        }
    }
}
