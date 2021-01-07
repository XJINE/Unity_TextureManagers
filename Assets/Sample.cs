using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    #region Field

    public  GameObject            sampleObject;
    public  List<TextureManagers> textureManagersList;

    #endregion Field

    #region Method

    private void Awake()
    {
        foreach (var textureManagers in textureManagersList)
        {
            textureManagers.Initialize();
        }
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Return))
        {
            return;
        }

        GameObject newObject = GameObject.Instantiate(sampleObject);

        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();

        materialPropertyBlock.SetTexture("_MainTex", TexturePickerProbabilities.Pick(textureManagersList[0]).texture);

        newObject.GetComponent<Renderer>().SetPropertyBlock(materialPropertyBlock);
    }

    private void OnGUI()
    {
        GUILayout.Label("Press Return to pick random texture and generate object.");
    }

    #endregion Method
}