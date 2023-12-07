using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class GetLocation : MonoBehaviour
{
    [HideInInspector]
    public string lon;
    [HideInInspector]
    public string lat;
    [HideInInspector]
    public string cityName;

    public LocationInfo Info;
    public WeatherData weatherData;

    //
    void Start()
    {
        StartCoroutine(GetCoordinates());
    }

    private IEnumerator GetCoordinates()
    {
        //Call API to get geolocation info
        using (var request = new UnityWebRequest("https://ipapi.co//json/")
        {
        downloadHandler = new DownloadHandlerBuffer()
        })
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                request.Dispose();
                //error
                yield break;
            }

            //Download JSON
            Info = JsonUtility.FromJson<LocationInfo>(request.downloadHandler.text);

            //Send location info to weatherdata
            lat = Info.latitude;
            lon = Info.longitude;
            cityName = Info.city;

            //Garbage dispose
            request.disposeUploadHandlerOnDispose = true;
            request.disposeDownloadHandlerOnDispose = true;
            request.Dispose();

            //Start weatherdata
            weatherData.Begin();
        }
        
    }
}

//JSON parsing
[Serializable]
public class LocationInfo
{
    public string ip;
    public string city;
    public string region;
    public string region_code;
    public string country;
    public string country_name;
    public string continent_code;
    public bool in_eu;
    public int postal;
    public string latitude;
    public string longitude;
    public string timezone;
    public int utc_offset;
    public int country_calling_code;
    public string currency;
    public string languages;
    public string asn;
    public string org;

}