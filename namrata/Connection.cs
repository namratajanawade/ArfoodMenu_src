using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class Connection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public IEnumerator GetRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/ARMenu/Get.php"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = "http://localhost/ARMenu/Get.php".Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    public IEnumerator Login(string userid,string usrpassword)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", userid);
        form.AddField("loginPass", usrpassword );

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ARMenu/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.


