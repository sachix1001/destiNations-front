using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using Vectrosity;
using System.Text;


// added
class DataItem
{
    public string username;
}
// end

public class ClientAPI : MonoBehaviour
{
    [SerializeField]
    Airplane[] prefabs;

    [SerializeField]
    ScavengerHunt[] window;

    public string url;
    public static object planeData = "the data";
    public string result;
    public object data;
    public CountryFacts facts;
    public fullScreenFacts fullFacts;
    public GameObject globe;
    private Airplane instance;
    private GameObject departure;
    private GameObject arrival;
    private VectorLine spline;
    private int segments = 100;
    public bool loop = true;
    public GameObject huntImg;
    List<Airplane> airplanes;
    private int x;
    private int y;
    private int z;
    public GameObject hunt;
    public GameObject load;
    public GameObject UI;
    //List<string> countryCodes = new List<string> () {"EG", "US", "DE", "GR", "FR", "CN", "BR", "GB", "AU", "CA", "RU", "JP", "TR", "UK", "TH", "MX", "PH", "DZ", "AE", "ZA", "KR", "ES", "AR", "IN"};
    private int length;
    void Awake()
	{
        airplanes = new List<Airplane>();
    }

    void Start()
    {
        load = GameObject.Find("/Loading");
        UI = GameObject.Find("/UIComponents");
        UI.SetActive(false);
        StartCoroutine(Get(url));
    }


    public IEnumerator Get(string url)
    {
        using(UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    result = @System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
       

                    globe = GameObject.Find("/earth/Icosphere");


                    var N = JSON.Parse(result);
                    // assign the length of all the to-from Array into an integer (118, on 03/09 evening)
                    length = Int32.Parse(N["length"].Value);
                    System.Random random = new System.Random();
                    x = random.Next(0, length);
                    y = random.Next(0, length);
                    z = random.Next(0, length);
                    // Debug.Log($"plane number {x}");

                    for (int i = 0; i < length; i++)
                    {
                 
                        //bool hasCCto = countryCodes.Contains(N["data"]);
                        //bool hasCCfrom = countryCodes.Contains(N["data"][i]["from"]["country"]["cc"]);

                        //if (hasCCto && hasCCfrom) {
                            Airplane instance = Instantiate(prefabs[0]);
                            Transform p = instance.transform;
                            p.parent = globe.transform;
                            //p.localPosition = new Vector3(-2.999408f, -2.960107f - i, -.1357397f);
                            instance.ccTo = N["data"][i]["to"]["country"]["cc"];
                            instance.ccFrom = N["data"][i]["from"]["country"]["cc"];
                            instance.countryName = N["data"][i]["to"]["country"]["name"];
                            instance.flag = N["data"][i]["to"]["country"]["flag"];
                            instance.language = N["data"][i]["to"]["country"]["languages"][0]["name"];
                            instance.greeting = N["data"][i]["to"]["country"]["greeting"];
                            instance.animal = N["data"][i]["to"]["country"]["animal"];
                            WatsonTextToSpeech.greeting = N["data"][i]["to"]["country"]["greeting"];
                            // instance.greeting = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes($"{greet}")));


                    departure = GameObject.FindGameObjectWithTag($"{instance.ccFrom}");
                            arrival = GameObject.FindGameObjectWithTag($"{instance.ccTo}");
                            if (departure != null && arrival != null) 
                            {
                            Vector3 midpoint = (departure.transform.position + arrival.transform.position) * 0.5f;
                            float dist = Vector3.Distance(departure.transform.position, arrival.transform.position);

                            p.position = Vector3.MoveTowards(midpoint, globe.transform.position, dist * -0.4f);
                            p.LookAt(Vector3.MoveTowards(arrival.transform.position, globe.transform.position, -2f));
                            
                            //p.localRotation = Quaternion.Euler(208.305f, -2.268005f, -48.89499f);
                            //p.localScale = new Vector3(0.3f, 0.3f, 0.3f);

                            //change plane texture to flag texture of destination country
                            instance.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(instance.ccTo) as Texture2D;
                            
                            var splinePoints = new List<Vector3>();
                            splinePoints.Add(departure.transform.localPosition);
                            splinePoints.Add(p.localPosition);
                            splinePoints.Add(arrival.transform.localPosition);
                            spline = new VectorLine("Spline", new List<Vector3>(segments + 1), 3.0f, LineType.Continuous); //LineType.Discrete
                            //spline.SetColor(new Color(204, 0, 82));
                            spline.MakeSpline(splinePoints.ToArray(), segments, loop);
                            //spline.MakeSpline(splinePoints.ToArray());
                            //spline.textureScale = 1.0f;
                            spline.drawTransform = globe.transform;
                            airplanes.Add(instance);
                            //Material lineMat = Resources.Load("ArcLine", typeof(Material)) as Material;
                            //spline.material = lineMat;
                            spline.Draw3DAuto();
                        //}

                            }

                    }
                    load.SetActive(false);
                    UI.SetActive(true);

                    hunt = GameObject.Find("/UIComponents/ScavengerHunt/huntImg");

                    // hunt.GetComponent<ScavengerHunt>().language = N["data"][x]["to"]["country"]["languages"][0]["name"];

                    hunt.GetComponent<ScavengerHunt>().countryname1 = N["data"][y]["to"]["country"]["name"];
                    hunt.GetComponent<ScavengerHunt>().animal = N["data"][y]["to"]["country"]["animal"];
                    answerOne.countryCode = N["data"][y]["to"]["country"]["cc"];

                    hunt.GetComponent<ScavengerHunt>().countryname3= N["data"][z]["to"]["country"]["name"];
                    hunt.GetComponent<ScavengerHunt>().flag = N["data"][z]["to"]["country"]["cc"];
                    ScavengerHunt.CC = N["data"][z]["to"]["country"]["cc"];
                    answerThree.countryCode = N["data"][z]["to"]["country"]["cc"];

                    while (N["data"][x]["to"]["country"]["languages"][0]["name"].Value == "English" || N["data"][x]["to"]["country"]["languages"][0]["name"].Value == "Spanish")
                    {
                   
                        x = random.Next(0, length);
                    }
                  
                    hunt.GetComponent<ScavengerHunt>().language = N["data"][x]["to"]["country"]["languages"][0]["name"];
                    hunt.GetComponent<ScavengerHunt>().countryname2 = N["data"][x]["to"]["country"]["name"];
                    answerTwo.countryCode = N["data"][x]["to"]["country"]["cc"];
                }
                else
                {
                    Debug.Log("Error: Could not get data");
                }
            }
        }
    }
}
