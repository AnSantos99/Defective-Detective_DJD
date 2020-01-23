using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PictureInteractable : InventoryItemBase
    {
        public string ID;

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
