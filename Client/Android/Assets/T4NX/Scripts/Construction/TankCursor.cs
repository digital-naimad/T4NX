using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{
    public class TankCursor : CustomSprite
    {
        public Vector2Int Position
        {
            get { return new Vector2Int((int)transform.position.x, (int)transform.position.y); }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Changes transform position with new Vector3 given by parameters
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(int x, int y)
        {
            this.transform.position = new Vector3(x, y);
        }

        
    }
}