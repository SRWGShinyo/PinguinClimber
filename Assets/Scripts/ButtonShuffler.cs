using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShuffler : MonoBehaviour
{
    public Sprite green;
    public Sprite greenPressed;

    public Sprite red;
    public Sprite redPressed;

    public Sprite pink;
    public Sprite pinkPressed;

    public Sprite blue;
    public Sprite bluePressed;

    public void ShuffleButtons(List<GameObject> buttons)
    {
        int chosen1 = Random.Range(0, buttons.Count);
        GameObject chosen = buttons[chosen1];
        buttons.RemoveAt(chosen1);

        int chosen2 = Random.Range(0, buttons.Count);
        GameObject chosenb2 = buttons[chosen2];
        buttons.RemoveAt(chosen2);

        ButtonScript btn1 = chosen.GetComponent<ButtonScript>();
        ButtonScript btn2 = chosenb2.GetComponent<ButtonScript>();

        PlatformController.PlatformColors colorTemp = btn1.color;
        SpriteState sprite = new SpriteState();

        switch (btn2.color)
        {
            case PlatformController.PlatformColors.BLUE:
                sprite.pressedSprite = bluePressed;
                chosen.GetComponent<Button>().spriteState = sprite;
                chosen.GetComponent<Image>().sprite = blue;
                btn1.color = PlatformController.PlatformColors.BLUE;
                btn1.pressedSprite = bluePressed;
                btn1.releasedSprite = blue;
                break;
            case PlatformController.PlatformColors.ORANGE:
                sprite.pressedSprite = greenPressed;
                chosen.GetComponent<Button>().spriteState = sprite;
                chosen.GetComponent<Image>().sprite = green;
                btn1.color = PlatformController.PlatformColors.ORANGE;
                btn1.pressedSprite = greenPressed;
                btn1.releasedSprite = green;
                break;
            case PlatformController.PlatformColors.PURPLE:
                sprite.pressedSprite = pinkPressed;
                chosen.GetComponent<Button>().spriteState = sprite;
                chosen.GetComponent<Image>().sprite = pink;
                btn1.color = PlatformController.PlatformColors.PURPLE;
                btn1.pressedSprite = pinkPressed;
                btn1.releasedSprite = pink;
                break;
            case PlatformController.PlatformColors.RED:
                sprite.pressedSprite = redPressed;
                chosen.GetComponent<Button>().spriteState = sprite;
                chosen.GetComponent<Image>().sprite = red;
                btn1.color = PlatformController.PlatformColors.RED;
                btn1.pressedSprite = redPressed;
                btn1.releasedSprite = red;
                break;
        }

        SpriteState sprite2 = new SpriteState();
        switch (colorTemp)
        {
            case PlatformController.PlatformColors.BLUE:
                sprite2.pressedSprite = bluePressed;
                chosenb2.GetComponent<Button>().spriteState = sprite2;
                chosenb2.GetComponent<Image>().sprite = blue;
                btn2.color = PlatformController.PlatformColors.BLUE;
                btn2.pressedSprite = bluePressed;
                btn2.releasedSprite = blue;
                break;
            case PlatformController.PlatformColors.ORANGE:
                sprite2.pressedSprite = greenPressed;
                chosenb2.GetComponent<Button>().spriteState = sprite2;
                chosenb2.GetComponent<Image>().sprite = green;
                btn2.color = PlatformController.PlatformColors.ORANGE;
                btn2.pressedSprite = greenPressed;
                btn2.releasedSprite = green;
                break;
            case PlatformController.PlatformColors.PURPLE:
                sprite2.pressedSprite = pinkPressed;
                chosenb2.GetComponent<Button>().spriteState = sprite2;
                chosenb2.GetComponent<Image>().sprite = pink;
                btn2.color = PlatformController.PlatformColors.PURPLE;
                btn2.pressedSprite = pinkPressed;
                btn2.releasedSprite = pink;
                break;
            case PlatformController.PlatformColors.RED:
                sprite2.pressedSprite = redPressed;
                chosenb2.GetComponent<Button>().spriteState = sprite2;
                chosenb2.GetComponent<Image>().sprite = red;
                btn2.color = PlatformController.PlatformColors.RED;
                btn2.pressedSprite = redPressed;
                btn2.releasedSprite = red;
                break;
        }

        if (buttons.Count != 0)
            ShuffleButtons(buttons);
    }
}
