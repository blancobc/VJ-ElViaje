using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Links : MonoBehaviour
{
    public void abrirUrlVerkami()
    {
        PlayerPrefs.SetInt("amigo", 1);
        Application.OpenURL("https://www.verkami.com/projects/29559-el-viaje-un-cuento-para-bebes");
    }

    public void abrirUrlLHC()
    {
        Application.OpenURL("http://lhc.epizy.com/");
    }

    public void abrirUrlCuentosCrecientes()
    {
        Application.OpenURL("https://www.instagram.com/cuentoscrecientes/");
    }
}
