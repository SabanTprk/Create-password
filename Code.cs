using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Code : MonoBehaviour
{
    public Toggle lowercaseToggle;
    public Toggle uppercaseToggle;
    public Toggle specialCharsToggle;
    public Toggle numbersToggle;
    public Slider lengthSlider;
    public TextMeshProUGUI passwordText;
    public TextMeshProUGUI valueText;
    public GameObject firstImage;
    public GameObject secondImage;
    public TextMeshProUGUI note;
    public Image ImageNote;

    string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
    string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string specialChars = "!@#$%^&*()_+-=[]{};:,.<>?";
    string numbers = "1234567890";

    void Start()
    {
        numbersToggle.isOn = true;  
        lowercaseToggle.isOn = false;
        uppercaseToggle.isOn = false;
        specialCharsToggle.isOn = false;

        lengthSlider.value = 7;
    }

    public void Update()
    {
        SliderValueRestart();
    }

    public void GeneratePasswordOnClick()
    {
        GeneratePassword();
    }

    void GeneratePassword()
    {
        string selectedChars = "";

        if (lowercaseToggle.isOn)
            selectedChars += lowercaseChars;
        
        if(numbersToggle.isOn)
            selectedChars += numbers;

        if (uppercaseToggle.isOn)
            selectedChars += uppercaseChars;

        if (specialCharsToggle.isOn)
            selectedChars += specialChars;

        int passwordLength = (int)lengthSlider.value;
        string password = "";

        if (selectedChars != "")
        {
            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = Random.Range(0, selectedChars.Length);
                password += selectedChars[randomIndex];
            }
        }

        passwordText.text = password;
    }

    public void SliderValueRestart() {
        int sliderValue = Mathf.RoundToInt(lengthSlider.value);
        valueText.text = sliderValue.ToString();

    }

    public void TextCopy()
    {
        GUIUtility.systemCopyBuffer = passwordText.text;

        //activeSelf nesnenin aktif olup olmaðýdýný kontrol eder.
        if (!ImageNote.gameObject.activeSelf)
        {
            ImageNote.gameObject.SetActive(true);
        }


        if (note.color == Color.black)
        {
            note.color = Color.red;
        }
        else
        {
            note.color = Color.black;
        }
    }

    public void ValueMinus()
    {
        lengthSlider.value --;
    }

    public void ValuePlus()
    {
        lengthSlider.value ++;
    }

    public void ImageChange()
    {
        if (firstImage.activeSelf)
        {
            firstImage.SetActive(false);
            secondImage.SetActive(true);
        }
        else
        {
            firstImage.SetActive(true);
            secondImage.SetActive(false);
        }
    }
}
