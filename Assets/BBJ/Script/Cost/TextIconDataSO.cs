namespace Icon
{
    using UnityEngine;
    using TMPro;
    using CustomEditor;

    [CreateAssetMenu(fileName = "TextIcon", menuName = "SO/TextIcon")]
    public class TextIconDataSO : ScriptableObject
    {
        [Space]
        [SerializeField, ReadOnly] private Sprite icon;
        [SerializeField, ReadOnly] private string id;

        /// <summary>
        /// SpriteAsset은
        /// Assets/TextMeshPro/Ressources/Sprite Assets
        /// 파일에 넣어야함
        /// </summary>
        
        [Space]
        [field: SerializeField] private TMP_SpriteAsset spriteAsset;
        [field: SerializeField] private string spriteName;

        public string ID => id;
        public void OnValidate()
        {
            string name = null;
            Sprite sprite = null;

            if (spriteAsset == null) return;
            var index = spriteAsset.GetSpriteIndexFromName(spriteName);

            if (index != -1)
            {
                name = spriteAsset.spriteCharacterTable[index].name;
                name = $"<sprite=\"{name}\" index=0>";
                sprite = spriteAsset.spriteGlyphTable[index].sprite;
            }

            id = name;
            icon = sprite;
        }
        public override string ToString() => id;
    }
}