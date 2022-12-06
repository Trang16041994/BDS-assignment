using System.Collections;
using System.Collections.Generic;
using System;

namespace APIHandler{
     [Serializable]
    public class JsonImage
    {
        public int albumId;
        public int id;
        public string title;
        public string url;
        public string thumbnailUrl;
        public bool isFetched = false;
    }
     [Serializable]
    public class JsonImageList
    {
        public List<JsonImage> listImages;
    }
}
