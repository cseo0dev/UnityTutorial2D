using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    private int number1 = 10;

    // Ä¸½¶È­ (number1Àº private¶ó Á¢±ÙÀÌ ºÒ°¡´ÉÇÏ¿© Ä¸½¶È­?)
    public int Number1
    {
        get
        { 
            return number1;
        }
        set
        {
            number1 = value;
        }
    }

    public int number2 = 20;
}
