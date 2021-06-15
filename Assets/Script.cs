using Firebase.Database;
using Firebase;
//using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script : MonoBehaviour
{

    DatabaseReference reference;
    public InputField Email;
    public Text showLoadedText;


    // Start is called before the first frame update
    void Start()
    {

        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://farmvillarestapi-default-rtdb.firebaseio.com/");
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveData()
    {
        reference.Child("Users").Child("User 1").Child("Email").SetValueAsync(Email.text.ToString());
    }

    public void loadData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").ValueChanged += Script_ValueChanged;
    }

    private void Script_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        showLoadedText.text = e.Snapshot.Child("User 1").Child("Email").GetValue(true).ToString();
    }
}
