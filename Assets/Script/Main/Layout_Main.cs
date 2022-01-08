using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Layout_Main : MonoBehaviour
{

    // 系統介面
    public Text systemMessage_text;
    TextSetting systemMessage;

    public Text userMessage_text;
    TextSetting userMessage;

    public Text result_text;
    TextSetting result;

    // 輸入訊息
    public InputField userMessage_inputField;
    InputFieldSetting userInput;

    // Button
    public Button enter_button;
    ButtonSetting Enter;

    public Button exit_button;
    ButtonSetting exit;

    // 結果
    public Image resultBreakGroud_image;
    ImageSetting resultBreakGroud;

    public Text resultDisPlay_text;
    TextSetting resultDisPlay;

    public Font font;

    // 回傳
    public static string USER_INPUT_MESSAGE;

    // Start is called before the first frame update
    void Start()
    {
        // Text
        systemMessage = new TextSetting(systemMessage_text, 0.2f, 1.78f, 1, 0.24f);
        systemMessage.function(font, FontStyle.Normal, "斷詞", TextAnchor.MiddleCenter, Color.red, 10);

        userMessage = new TextSetting(userMessage_text, 0.35f, 1.5f, 0.51f, 0.24f);
        userMessage.function(font, FontStyle.Normal, "請輸入句子", TextAnchor.MiddleCenter, Color.red, 10);

        result = new TextSetting(result_text, 1.1f, 1.66f, 1, 0.24f);
        result.function(font, FontStyle.Normal, "結果", TextAnchor.MiddleCenter, Color.red, 10);

        // button
        Enter = new ButtonSetting(enter_button, 0.25f, 0.8f, 0.3f, 0.25f, new EnterOnClick().onClick);
        Enter.function(font, FontStyle.Normal, "確定", TextAnchor.MiddleCenter, Color.black, 10);

        exit = new ButtonSetting(exit_button, 0.62f, 0.8f, 0.3f, 0.25f, new ExitOnClick().onClick);
        exit.function(font, FontStyle.Normal, "離開", TextAnchor.MiddleCenter, Color.black, 10);

        // image
        resultBreakGroud = new ImageSetting(resultBreakGroud_image, 1.38f, 0.9f, 1.05f, 1.15f);
        resultBreakGroud.function(null, true, false, resultDisPlay_text.rectTransform);

        resultDisPlay = new TextSetting(resultDisPlay_text);

        // inputField
        userInput = new InputFieldSetting(userMessage_inputField, 0.46f, 1.18f, 0.73f, 0.25f);
        userInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 11);

    }

    // Update is called once per frame
    void Update()
    {      
        resultDisPlay.function(18, new Vector2(0.5f, 0));

        resultDisPlay.setMessage(EnterOnClick.RESULT);
        USER_INPUT_MESSAGE = userInput.getMessage();

    }
}
