using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailUs : MonoBehaviour
{
    public void openEmail() {
        Application.OpenURL("mailto:pesug20cs442@pesu.pes.edu");
    }
    
}
