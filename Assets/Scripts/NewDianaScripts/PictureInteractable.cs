using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// this class defines a clue of the picture type 
/// </summary>
public class PictureInteractable : InventoryItemBase
    {
        /// <summary>
        /// gets picture number
        /// </summary>
        public string ID;

        /// <summary>
        /// joins clue and ID to get current picture
        /// </summary>
        public override string Name
        {
            get
            {
                return "Clue" + ID;
            }
        }

        public override void OnUse()
        {
            //
        }
    
}
