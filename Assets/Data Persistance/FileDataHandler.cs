using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler 
{
    private string dataDirPath = "";
    private string dataFilename = "";

    public FileDataHandler(string dataDirPath, string dataFilename)
    {
        this.dataDirPath = dataDirPath;
        this.dataFilename = dataFilename;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFilename);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData=JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch(Exception e) 
            {

                Debug.LogError("Error occured whem trying to load data file:" + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data) 
    { 
        string fullPath= Path.Combine(dataDirPath, dataFilename);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToSecure=JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToSecure);
                }
            }
        }
        catch(Exception e)     
        {
            Debug.LogError("Error occured whem trying to save data file:" +fullPath + "\n"+e);
        }
    }
}
