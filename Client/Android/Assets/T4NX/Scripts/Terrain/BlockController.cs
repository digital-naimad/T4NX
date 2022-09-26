using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class BlockController : MonoBehaviour
    {
        [SerializeField] private BlockType _blockType;
        [SerializeField] private MeshRenderer meshRenderer;
       
        public BlockType BlockType
        {
            get { return _blockType; }

        }

        private Material material;

        // Start is called before the first frame update
        void Start()
        {
            //material = meshRenderer.sharedMaterial;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetType(BlockType blockType)
        {
           // m//aterial.SetInt
        }
    }
}
