using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public PlatformController.PlatformColors color;
    public KeyCode key;
    private Button button;

    public Sprite pressedSprite;
    public Sprite releasedSprite;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Image image = GetComponent<Image>();
            button.onClick.Invoke();
            image.sprite = pressedSprite;
        }

        if (Input.GetKeyUp(key))
        {
            Image image = GetComponent<Image>();
            image.sprite = releasedSprite;
        }
    }


    public void Pressed()
    {
        EventSystem.current.SetSelectedGameObject(null);
        PlatformController.platformContr.Dispatch(color);
    }
}
