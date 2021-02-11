using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public List<Button> buttons { get; set; }
    public GridManager(Button button)
    {
        buttons.Add(button);
    }
    private void Start()
    {
        GameManager gameManager = new GameManager();

    }
}
