using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
abstract public class classTest : MonoBehaviour
{
    // Start is called before the first frame update
    
        public string[] inventory ;
        
        public classTest(string[] items){
            inventory=items;
        }
        public string[] GetItems(){
            return inventory;
        }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }



    
}


