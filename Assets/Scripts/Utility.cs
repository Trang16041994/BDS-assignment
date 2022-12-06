using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System;
using UnityEngine.UI;

namespace APIHandler{
   public class Utility
   {
      public static JsonImageList fetchJsonImage(){

         string api = "https://jsonplaceholder.typicode.com/photos";
         HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api);
         HttpWebResponse response = (HttpWebResponse)request.GetResponse();
         StreamReader reader = new StreamReader(response.GetResponseStream());
         // The reason for the addition below: https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
         string jsonResponse = "{\"listImages\":" + reader.ReadToEnd() + "}";
         JsonImageList jsonImageList = JsonUtility.FromJson<JsonImageList>(jsonResponse);
         return jsonImageList;
      }

      public static Image DownloadImage(JsonImageList listJsonImage, Image image, int index) 
      {
            image.sprite = null;
            Davinci.get().load(listJsonImage.listImages[index].url).into(image).start();
            // Download image request might be blocked by the via.placeholder.com service used by JSONPLACEHOLDER. If that is the case, for the sake of this test, an alternative image source will be used. The real backend should not block the client like this. 
            if (image.sprite == null) 
            {
               // The urls are fetched properly from jsonplaceholder. Look at the debug log.
               Debug.Log("the url of image " + listJsonImage.listImages[index].id + " is: " + listJsonImage.listImages[index].url);
               int id = 10 + listJsonImage.listImages[index].id; // Just randomly choose 10 as the starting image in picsum.photos
               string backupUrl = String.Format("https://picsum.photos/id/{0}/500", listJsonImage.listImages[index].id);
               Davinci.get().load(backupUrl).setCached(false).into(image).start();
            }
            return image;
      }
   }
}
