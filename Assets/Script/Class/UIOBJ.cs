﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class UIOBJ 
{
    public abstract class Button_Setting {

        protected float pointX, pointY, sizeX, sizeY;
        protected UnityAction onClick;
        protected Button button;

        public Button_Setting(Button button, float pointX, float pointY, float sizeX, float sizeY, UnityAction onClick) {

            this.button = button;
            this.pointX = pointX;
            this.pointY = pointY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.onClick = onClick;
        }

        public abstract Button function(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor, 
            Color color, int textSize);
    }

    public abstract class Text_Setting
    {
        protected Text text;
        protected float pointX, pointY, sizeX, sizeY;

        public Text_Setting(Text text, float pointX, float pointY, float sizeX, float sizeY) {

            this.text = text;
            this.pointX = pointX;
            this.pointY = pointY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        public Text_Setting(Text text) {
            this.text = text;
        }

        public abstract Text function(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor,
            Color color, int textSize);

        public abstract Text function(int fontsize, Vector2 pivot);
    }

    public abstract class Image_Setting
    {
        protected Image image;
        protected float pointX, pointY, sizeX, sizeY;

        public Image_Setting(Image image, float pointX, float pointY, float sizeX, float sizeY)
        {
            this.image = image;
            this.pointX = pointX;
            this.pointY = pointY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        public abstract Image function(Sprite sprite);
        public abstract Image function(Sprite sprite, bool horizontal, bool vertical, RectTransform content);
    }

    public abstract class InputField_Setting
    {
        protected InputField inputField;
        protected float pointX, pointY, sizeX, sizeY;

        public InputField_Setting(InputField inputField, float pointX, float pointY, float sizeX, float sizeY)
        {
            this.inputField = inputField;
            this.pointX = pointX;
            this.pointY = pointY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        public abstract InputField function(Font font, FontStyle fontStyle,  TextAnchor textAnchor, Color color, int textSize);
    }
}

public interface OnClick
{
    void onClick();
}
