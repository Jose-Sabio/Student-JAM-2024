using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
      // Este método se llamará cuando se presione un botón u ocurra algún evento que desee cambiar de escena.
    public void OnBotonInicio()
    {
        SceneManager.LoadScene("EscenaInicio");
    }
    public void OnBotonJugar(){
        SceneManager.LoadScene("EscenaNave");
    }
    public void OnBotonCreditos(){
        SceneManager.LoadScene("EscenaCreditos");
    }
      public void OnBotonControles(){
        SceneManager.LoadScene("EscenaControles");
    }
}

