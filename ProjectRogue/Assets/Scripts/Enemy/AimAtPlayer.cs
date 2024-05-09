using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayer : MonoBehaviour
{
    [SerializeField] private float rotationOffset = -90;

    // Update is called once per frame
    private void Update()
    {
        Vector3 playerPosition = GameManager.Instance.Player.transform.position;
        playerPosition.z = 0f;

        Vector3 direction = playerPosition - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(playerPosition.x >= transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if(transform.localScale.x < 0 && playerPosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if(transform.lossyScale.x <= 0f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationOffset + 180f));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationOffset));
        }
    }
}
