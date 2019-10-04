using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements; //needed for unity 2019, remove if using 2018. 2017 and earlier not tested
using UnityEngine.UIElements; //needed for unity 2019, remove if using 2018. 2017 and earlier not tested

//Code by Robert Rood, Originally made for use in Unity 2019.1, MIT License

[System.Serializable]
public class ObjectPool
{

    public GameObject pooledObject;
    public int poolSize = 10;
    public bool canResize = true;
    public PoolType poolType;
    public List<GameObject> pooledObjects;
    public string poolName; //optional, allows for pool to be referenced by name, first pool with matching name will be used
}


[CustomPropertyDrawer(typeof(ObjectPool))]
public class ObjectPoolDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        //var indent = EditorGUI.indentLevel;
        //EditorGUI.indentLevel = 0;

        var nameField = new Rect(position.x - 40, position.y + 20, 150, 16);
        var objectField = new Rect(position.x - 40, position.y + 40, 150, 16);
        var sizeField = new Rect(position.x - 40, position.y + 60, 50, 16);
        var resizeField = new Rect(position.x + 80, position.y + 60, 30, 16);
        var typeField = new Rect(position.x - 40, position.y + 80, 150, 16);



        EditorGUI.LabelField(new Rect(nameField.x - 86, nameField.y, 80, nameField.height), new GUIContent("Pool Name"));
        EditorGUI.LabelField(new Rect(objectField.x - 86, objectField.y, 98, objectField.height), new GUIContent("Pooled Object"));
        EditorGUI.LabelField(new Rect(sizeField.x - 86, sizeField.y, 80, sizeField.height), new GUIContent("Pool Size"));
        EditorGUI.LabelField(new Rect(resizeField.x - 72, resizeField.y, 84, resizeField.height), new GUIContent("Can Resize"));
        EditorGUI.LabelField(new Rect(typeField.x - 86, typeField.y, 84, typeField.height), new GUIContent("Pool Type"));


        EditorGUI.PropertyField(nameField, property.FindPropertyRelative("poolName"), GUIContent.none);
        EditorGUI.PropertyField(objectField, property.FindPropertyRelative("pooledObject"), GUIContent.none);
        EditorGUI.PropertyField(sizeField, property.FindPropertyRelative("poolSize"), GUIContent.none);
        EditorGUI.PropertyField(resizeField, property.FindPropertyRelative("canResize"), GUIContent.none);
        EditorGUI.PropertyField(typeField, property.FindPropertyRelative("poolType"), GUIContent.none);


        //EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
        //return base.CreatePropertyGUI(property);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 100;
    }
}


public enum PoolType
{
    GameObject, ParticleSystem

}

