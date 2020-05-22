using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ScriptableObjectSaveLoad : MonoBehaviour
{

    [Tooltip("Leaving this field as 'null' will save in the root of the persistent data path.")]
    [SerializeField] private string saveFolder = null;
    [SerializeField] private bool loadOnAwake = false;
    [SerializeField] private bool loadOnEnable = false;
    [SerializeField] private bool loadOnStart = false;
    [SerializeField] private bool saveOnDisable = false;
    [Tooltip("All scriptable objects will save as the name of the scriptable object.")]
    [SerializeField] private ScriptableObject[] saveObjects = new ScriptableObject[1];

    private void Awake()
    {
        if (loadOnAwake)
        {
            Load();
        }
    }

    private void OnEnable()
    {
        if (loadOnEnable)
        {
            Load();
        }
    }

    private void Start()
    {
        if (loadOnStart)
        {
            Load();
        }
    }

    private void OnDisable()
    {
        if (saveOnDisable)
        {
            Save();
        }
    }

    public void Save()
    {
        // Create save data directory if none exist
        if (!Directory.Exists(Application.persistentDataPath + "/" + saveFolder))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + saveFolder);
        }

        // Saves each array entry
        for (int i = 0; i < saveObjects.Length; i++)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + saveFolder + "/" + saveObjects[i].name + ".json");
            string json = JsonUtility.ToJson(saveObjects[i]);
            // May want to put a layer of generic encryption here
            bf.Serialize(file, json);
            file.Close();
        }
    }

    public void Load()
    {
        // Create a save data directory if none exist
        if (!Directory.Exists(Application.persistentDataPath + "/" + saveFolder))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + saveFolder);
        }

        // Load each array entry
        for (int i = 0; i < saveObjects.Length; i++)
        {
            // Make sure save file exists
            if (File.Exists(Application.persistentDataPath + "/" + saveFolder + "/" + saveObjects[i].name + ".json"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/" + saveFolder + "/" + saveObjects[i].name + ".json", FileMode.Open);
                // May want to put a layer of generic decryption here
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), saveObjects[i]);
                file.Close();
            }
        }
    }

}
