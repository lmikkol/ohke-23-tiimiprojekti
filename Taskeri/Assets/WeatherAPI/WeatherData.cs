using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;


public class WeatherData : MonoBehaviour
{
    public bool locationInitialized;

    public TextMeshProUGUI currentWeatherText;
    public TextMeshProUGUI currentWindText;
    public TextMeshProUGUI titleText;

    public WeatherInfo weatherInfo;
    public GetLocation getLocation;

    public void Begin()
    {
        //Call weather API every 10 minutes
        //10 minutes is 600 seconds
        InvokeRepeating("UpdateWeather", 1, 600);
        locationInitialized = true;
    }


    void UpdateWeather()
    {
        if (locationInitialized)
        {
           StartCoroutine(GetWeatherInfo());       
        }
    }


    private IEnumerator GetWeatherInfo()
    {
        //Call weather API, latitude and longitude used to get location
        using (var www = new UnityWebRequest("https://api.open-meteo.com/v1/forecast?latitude=" + getLocation.lat + "&longitude=" + getLocation.lon + "&current=temperature_2m,wind_speed_10m&wind_speed_unit=ms")
        {
            downloadHandler = new DownloadHandlerBuffer()
        })
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                www.Dispose();
                //error
                yield break;
            }

            //Download JSON
            weatherInfo = JsonUtility.FromJson<WeatherInfo>(www.downloadHandler.text);

            //UI Text
            titleText.text = "Current weather in Tampere is: ";
            currentWeatherText.text = "Temperature: " + weatherInfo.current.temperature_2m + weatherInfo.current_units.temperature_2m;
            currentWindText.text = "Wind speed: " + weatherInfo.current.wind_speed_10m + " " +  weatherInfo.current_units.wind_speed_10m;

            //Dispose garbage
            www.disposeUploadHandlerOnDispose = true;
            www.disposeDownloadHandlerOnDispose = true;
            www.Dispose();
        }
    }

    //JSON parsing
    [Serializable]
    public class CurrentUnits
    {
        public string time;
        public string interval;
        public string temperature_2m;
        public string wind_speed_10m;
    }

    [Serializable]
    public class Current
    {
        public string time;
        public int interval;
        public float temperature_2m;
        public float wind_speed_10m;
    }

    [Serializable]
    public class WeatherInfo
    {
        public float latitude;
        public float longitude;
        public float generationtime_ms;
        public int utc_offset_seconds;
        public string timezone;
        public string timezone_abbreviation;
        public float elevation;
        public CurrentUnits current_units;
        public Current current;
    }
}

