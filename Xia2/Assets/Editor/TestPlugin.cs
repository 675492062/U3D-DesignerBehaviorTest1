// C# example:
using UnityEngine;
using UnityEditor;
public class MyWindow : EditorWindow {
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;

	static GameObject obj;
	// Add menu named "My Window" to the Window menu
	[MenuItem ("Test/Editor window")]
	static void Init () 
	{
		// Get existing open window or if none, make a new one:
		MyWindow window = (MyWindow)EditorWindow.GetWindow (typeof (MyWindow));
	}
	
	void OnGUI () 
	{
		if(GUILayout.Button ("Load config file"))
		{
			string path = EditorUtility.OpenFilePanel("Select config file", "", "");//
			Debug.Log("path: " + path);
		}
		if(GUILayout.Button ("Save config file"))
		{
			string path = EditorUtility.SaveFilePanel("Save config file", "", "config","");//
			Debug.Log("path: " + path);
		}

		GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
		myString = EditorGUILayout.TextField ("Text Field", myString);
		
		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
		myBool = EditorGUILayout.Toggle ("Toggle", myBool);
		myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup ();

		obj = EditorGUILayout.ObjectField("Notify", obj, typeof(GameObject), true) as GameObject;
		if( obj != null)
		{

		}
	}
}