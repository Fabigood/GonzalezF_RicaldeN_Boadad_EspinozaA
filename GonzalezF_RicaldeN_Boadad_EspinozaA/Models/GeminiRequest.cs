﻿namespace GonzalezF_RicaldeN_Boadad_EspinozaA.Models
{
    
        public class GeminiRequest
        {
            public List<Content> contents { get; set; }
        }

        public class Content
        {
            public List<Part> parts { get; set; }
        }

        public class Part
        {
            public string text { get; set; }
        }

    
}
