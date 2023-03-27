using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipSelect : MonoBehaviour
{
    public Sprite spaceshipSprite;
    public Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void SelectSpaceship()
    {
        spaceshipSprite = buttonImage.sprite;
    }
}
