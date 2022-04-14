using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]

public class DialoguesSettings : ScriptableObject
{

    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakrSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();

}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialoguesSettings))]
public class BuilderEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialoguesSettings ds = (DialoguesSettings)target;
        Languages l = new Languages();
        Sentences s = new Sentences();

        l.portuguese = ds.sentence;

        s.profile = ds.speakrSprite;
        s.sentence = l;

        if(GUILayout.Button("Create Dialogue"))
        {
            if(ds.sentence != "")
            {
                ds.dialogues.Add(s);

                ds.speakrSprite = null;
                ds.sentence = "";
            }
        }
    }

}

#endif
