using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace Cookout
{
    public class UserRegistration
    {  
        string id;
        string firstName;
        string lastName;
        string email;
        string pwd;
        string imageURL;
        string phoneNumber;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [JsonProperty(PropertyName = "email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [JsonProperty(PropertyName = "pwd")]
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        [JsonProperty(PropertyName = "imageURL")]
        public string ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }

        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }       

        [Version]
        public string Version { get; set; }
    }
}
