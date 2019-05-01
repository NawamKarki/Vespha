using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

using UnityEngine.SceneManagement;

public class greetCustomer : MonoBehaviour
{
    [SerializeField] GameObject notice; //trigger_2 dial value
    [SerializeField] Text value;
    [SerializeField] GameObject receptionist; //doorfront avatar

    //public string ParticipantNumber;

    private int dial;
    private float timer;
    private bool enterCountdown;
    private Animator receptionist_talk; //Animation of the doorfront avatar
   

    private string path;
    private long count;

    //Name of the folder to store files
    string folderName = DateTime.Now.ToString("yyyy-MM-dd");

    // Start is called before the first frame update
    void Start()
    {
        receptionist_talk = receptionist.GetComponent<Animator>();
        initialize();

    }

    // Update is called once per frame
    void Update()
    {
        if (enterCountdown)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer >= 3)
            {
                notice.SetActive(true);
                timer = 0;
                //SceneManager.LoadScene("VapingActivity");
            }
        }
    }

    //displaying the craving level meter
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            enterCountdown = true;
            //animate and make the avatar talk
            receptionist.GetComponent<AudioSource>().Play();
            receptionist_talk.Play("talk");
           


        }
    }

    //changing the values of the dial
    private void OnTriggerStay(Collider col)
    {

        if (Input.GetKeyDown("w"))
        {
            Debug.Log("value");
            dial += 1;

            value.text = dial.ToString();
        }

        if (Input.GetKeyDown("s"))
        {
            dial -= 1;

            value.text = dial.ToString();
        }
    }

    //removing the craving meter canvas 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            Debug.Log("Gone");
            Debug.Log(value.text);

            //sends dial value to be stored
            addValue(value.text);
            //Destroy(question);
            enterCountdown = false;
            notice.SetActive(false);
            
        }
    }

    //creates directory to store the data
    public void initialize()
    {
        //Sets the path for the game up to the Assets folder
        path = Application.dataPath;



        //Checks to see the amount of files in the Dialdata folder
        count = DirCount(new DirectoryInfo(path + "/" + folderName));

        //Creates the directory if needed
        if (checkDirectory(folderName) == false)
        {
            createDirectory(folderName);
        }


        //creates the new csv file and names it based on the amount of existing files
        if (checkFile(folderName +"participant " + count + ".csv") == false)
        {
            Debug.Log("A");
            
            //createfile ("dialdata","player" + count,"csv","player " + count);
            createFile(folderName, "participant " + count, "csv");
        }

        //print(readFile("gamedata", "Player" + count, "gamedata"));
    }

    //Counts the amount of files in the directory
    public static long DirCount(DirectoryInfo d)
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
            Debug.Log("B");
            return true;
            
            
        }
        else
        {
            Debug.Log("B1");
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
                Debug.Log("C");
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

    private void addValue(string dial)
    {
        string path1 = Application.dataPath + "/" + folderName;
        File.AppendAllText(path1 + "/" + "participant " + count +".csv", "\n" + dial);
        Debug.Log("Saved");
    }
}
