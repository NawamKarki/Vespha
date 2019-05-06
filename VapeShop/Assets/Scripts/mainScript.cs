using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class mainScript : MonoBehaviour
{

    private string path;
    public static long count = 0;

    //Name of the folder to store files
    string folderName = DateTime.Now.ToString("yyyy-MM-dd");

    // Start is called before the first frame update
    void Start()
    {
        initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //creates directory to store the data
    public void initialize()
    {
        //Sets the path for the game up to the Assets folder
        path = Application.dataPath;

        //Creates the directory if needed
        if (checkDirectory(folderName) == false)
        {
            createDirectory(folderName);
        }

        //Checks to see the amount of files in the Dialdata folder
        count = DirCount(new DirectoryInfo(path + "/" + folderName));

        //creates the new csv file and names it based on the amount of existing files
        if (checkFile(folderName + "participant " + count + ".csv") == false)
        {
            Debug.Log("A");

            //createfile ("dialdata","player" + count,"csv","player " + count);
            createFile(folderName, "participant " + count, "csv");
        }

        //print(readFile("gamedata", "Player" + count, "gamedata"));
    }

    //Counts the amount of files in the directory
    private long DirCount(DirectoryInfo d)
    {
        long i = 0;
        // Add file sizes
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis)
        {
            if (fi.Extension.Contains("csv"))
                i++;
        }
        return i;
    }

    //Checks to see if the directory exists
    private bool checkDirectory(string directory)
    {
        if (Directory.Exists(path + "/" + directory))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Creates the directory if it does not already exist
    private void createDirectory(string directory)
    {
        if (checkDirectory(directory) == false)
        {
            print("Creating directory: " + directory);
            Directory.CreateDirectory(path + "/" + directory);
        }
        else
        {
            print("Error: You are trying to create the directory " + directory + " but it already exists!");
        }
    }

    //Checks if the file exists
    public bool checkFile(string filePath)
    {
        if (File.Exists(path + "/" + filePath))
        {
            count += 1;
            //Debug.Log("B");
            return true;


        }
        else
        {
            //Debug.Log("B1");
            return false;

        }
    }

    public void createFile(string directory, string filename, string filetype)
    {
        print("Creating " + directory + "/" + filename + "." + filetype);

        if (checkDirectory(directory) == true)
        {
            if (checkFile(directory + "/" + filename + "." + filetype) == false)
            {
                Debug.Log("1" + count);
                File.WriteAllText(path + "/" + directory + "/" + filename + "." + filetype, "Craving Values");
            }
            else
            {
                print("The file " + filename + " already exists in " + path + "/" + directory);
            }
        }
        else
        {
            //print ("Unable to create file as the directory " + directory + " does not exist!");
        }
    }
}
