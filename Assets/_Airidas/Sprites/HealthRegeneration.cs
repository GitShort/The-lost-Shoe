using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    PickShoe pick;
    public PlayerHealth health;
    public float melting;
    bool healed = false;
    // Start is called before the first frame update
    void Start()
    {
        pick = GetComponent<PickShoe>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pick.isPickedUp)
        {
            if (health.health < health.numOfHearts && !healed)
            {
                health.health += 1;
                healed = true;
            }

            if (this.transform.localScale.x > 0.05 && this.transform.localScale.y > 0.05 && this.transform.localScale.z > 0.05)
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x - melting, this.transform.localScale.y - melting, this.transform.localScale.z - melting);
            }
            else if (this.transform.localScale.x < 0.05 && this.transform.localScale.y > 0.05 && this.transform.localScale.z > 0.05) // x < 0.05
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y - melting, this.transform.localScale.z - melting);
            }
            else if (this.transform.localScale.x > 0.05 && this.transform.localScale.y < 0.05 && this.transform.localScale.z > 0.05) // y < 0.05
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x - melting, this.transform.localScale.y, this.transform.localScale.z - melting);
            }
            else if (this.transform.localScale.x > 0.05 && this.transform.localScale.y > 0.05 && this.transform.localScale.z < 0.05) // z < 0.05
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x - melting, this.transform.localScale.y - melting, this.transform.localScale.z);
            }

            // Two checks

            else if (this.transform.localScale.x < 0.05 && this.transform.localScale.y < 0.05 && this.transform.localScale.z > 0.05) // x y < 0.05
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z - melting);
            }
            else if (this.transform.localScale.x < 0.05 && this.transform.localScale.y > 0.05 && this.transform.localScale.z < 0.05) // x z < 0.05
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y - melting, this.transform.localScale.z);
            }
            else if (this.transform.localScale.x > 0.05 && this.transform.localScale.y < 0.05 && this.transform.localScale.z < 0.05) // y z < 0.05
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x - melting, this.transform.localScale.y, this.transform.localScale.z);
            }

            if (this.transform.localScale.z < 0.05 && this.transform.localScale.x < 0.05 && this.transform.localScale.y < 0.05)
            {
                Destroy(gameObject);
            }
        }
    }
}
