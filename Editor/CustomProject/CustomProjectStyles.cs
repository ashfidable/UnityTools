using UnityEngine;

namespace CustomProjectView
{
    [CreateAssetMenu(menuName = "Project View/Project Styles")]
    public class CustomProjectStyles : ScriptableObject
    {
        [Header("Extensions Style")]
        public bool showFileExtensions;
        [SerializeField] [Tooltip("Increase the alpha channel to see the text.")] private Color textColor;
        [SerializeField] private bool randomTextColor;
        public Color TextColor => randomTextColor ? Random.ColorHSV() : textColor;

        [Header("Custom Style Data")]
        public StyleData[] styles;
    }

    [System.Serializable]
    public struct StyleData
    {
        public string folderOrFileName;

        [Header("Icon Styles")]
        public bool useIcons;
        public Icon iconType;
        [SerializeField] [Tooltip("Increase the alpha channel to see the icon.")] private Color iconColor;
        [SerializeField] private bool randomIconColor;
        public Color IconColor => randomIconColor ? Random.ColorHSV() : iconColor;

        [Header("Background Styles")]
        [Range(0, 1), Tooltip("Min 0 is off.  Max 1 is the default size.")] public float backgroundWidth;
        [Range(0, 1), Tooltip("Min 0 is off.  Max 1 is the default size.")] public float backgroundHeight;
        [SerializeField] [Tooltip("Increase the alpha channel to see the background.")] private Color backgroundColor;
        [SerializeField] private bool randomBackgroundColor;
        public Color BackgroundColor => randomBackgroundColor ? Random.ColorHSV() : backgroundColor;

        [Header("Text Styles")]
        [SerializeField] [Range(0, 16), Tooltip("Keep it 0 for default size. Max is 16 as per the range")] private int textSize;
        [SerializeField] [Tooltip("Increase the alpha channel to see the text.")] private Color32 textColor;
        [SerializeField] private TextAnchor textAlignment;
        [SerializeField] private FontStyle textStyle;
        public GUIStyle TextStyle => new GUIStyle()
        {
            normal = new GUIStyleState() { textColor = textColor },
            fontStyle = textStyle,
            alignment = textAlignment,
            richText = true,
            fontSize = textSize,
        };
    }

    public enum Icon { Bullet, Diamond, Heart, Triangle }
}
