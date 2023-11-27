using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class ItemCollector : MonoBehaviour
{
    private int points = 0;
    [SerializeField] private TextMeshProUGUI bananText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banan"))
        {
            points++;
            Debug.Log(points);
            Destroy(collision.gameObject);
            bananText.text = "Fruits: " + points;
        }
     
    }

}