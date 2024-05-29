using UnityEngine;

namespace GPP
{
    [System.Serializable]
    public class TreeData
    {
        public Vector2 position;
        public float height;
        public float thickness;
        public Color barkTint;
        public Color leavesTint;
    }

    [ExecuteInEditMode]
    public class Tree : MonoBehaviour
    {     
        [SerializeField] private SpriteRenderer leavesRenderer, barkRenderer;
        [SerializeField] private TreeData treeData;
        [SerializeField] private TreeModel treeModel;
        private void Awake()
        {
            leavesRenderer.sprite = treeModel.leaves;
            leavesRenderer.color = treeData.leavesTint;
            barkRenderer.sprite = treeModel.bark;
            barkRenderer.color = treeData.barkTint;

            transform.localScale = new Vector2(treeData.thickness,treeData.height);
        }
    }
}