using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using
using System.Collections;
using UnityEngine.Networking;

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
    //Changed URL to get data from A3Datasheet table
    //Before: public string _WebsiteURL = "https://testklemens.azurewebsites.net/tables/PractTest2?zumo-api-version=2.0.0";
    //After:
    public string _WebsiteURL = "https://testklemens.azurewebsites.net/tables/A3Datasheet?zumo-api-version=2.0.0";


    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        //string jsonResponse = Request.GET(_WebsiteURL);
        WWW myWww = new WWW(_WebsiteURL);
        while (myWww.isDone == false) ;
        {
        }
        string jsonResponse = myWww.text;

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        //Changed class and variable to get data from A3Datasheet script and table
        //Before: Emergency[] PractTest2 = JsonReader.Deserialize<Emergency[]>(jsonResponse);
        //After:
        A3[] A3Datasheet = JsonReader.Deserialize<A3[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL
        int totalCubes = 30;
        float totalDistance = 2.9f;
        int i = 0;

        //----------------------

        //We can now loop through the array of objects and access each object individually
        //Changed foreach to loop each objects based on data retrieved from A3Datasheet scrip and table
        //Before: foreach (Emergency Emergency in PracTest2)
        //After:
        foreach (A3 A3Table in A3Datasheet)
        {
            //Example of how to use the object
            //Changed debug log to display 'This card name is [Title]'
            //Before: Debug.Log("This emergency name is: " Emergency.EmergencyName);
            //After:
            Debug.Log("This card name is: " + A3Table.Title);
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
                
            float perc = i / (float)totalCubes;

            float sin = Mathf.Sin(perc * Mathf.PI / 2);

            float x = 1.8f + sin * totalDistance;
            float y = 5.0f;
            float z = 0.0f;

            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<CubeScript>().setSize(0.45f * (1.0f - perc));
            newCube.GetComponent<CubeScript>().rotateSpeed = 0.2f + perc * 2.0f; //4.0f
            //Changed text to display title of trello card
            //Before: newCube.transform.Find("New Text").GetComponent<TextMesh>().text = Emergency.EmergencyName;
            //After:
            newCube.transform.Find("New Text").GetComponent<TextMesh>().text = A3Table.Title;
            i++;

            //----------------------
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
