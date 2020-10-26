using Library_UWP.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_UWP.Model
{
    public class Person
    {
        public Person()
        {

        }

        public Person(string firstName, string lastName, string city, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            City = city;
        }


        //! obligarorisk-bra att vana med det for cosmos 
        [JsonProperty(propertyName: "id")]//install newtonsoft.json
        public int Id { get; set; }
        [JsonProperty(propertyName: "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(propertyName: "lastName")]
        public string LastName { get; set; }
        [JsonProperty(propertyName: "email")]
        public string Email { get; set; }
        [JsonProperty(propertyName: "city")]
        public string City { get; set; }
        public string DisplayName => $"{ FirstName }  { LastName}";
    }

    //++ VM for main.xaml

   
    public class PersonViewModel
    {//view model använda att hämta ut och visa saker// vi vill ha  lista 
     //lista - kan använda
        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();// gör new instance- var fel-not sätt instance object


        public PersonViewModel()//skapa lista i ctor -kan hämta från DB här-utan DATAACCESS DELEN 
        {
            People.Add(new Person("Nataliya", "Lisjö", "Degerfors", "natlisjo@gmail.com"));
            People.Add(new Person("Max", "Lisjö", "Degerfors", "maxlisjo@gmail.com"));
        }

        public void RemoveItem(Person person) //delete knapp f.
        {
            People.Remove(person);
        }

        public void AddItem(Person person)
        {
            People.Add(person);
        }
    } //=> till grafiska mainpage

    public class CustomerViewModel
    {
        public ObservableCollection<Person> Customers { get; set; }//--list

        //populera direct /instället göra hämtning 
        //public CustomerViewModel(string fileName)
        //{
        //    Customers = new ObservableCollection<Person>(); //ny instance /i den ++ info
        //    Customers = JsonConvert.DeserializeObject<ObservableCollection<Person>>(FileHelper.GetFileContentAsync(fileName).GetAwaiter().GetResult());//ge lista med people type customer
        //}

    }
}  /*vi ska bygga MVVM  view model utav det 
        * --finns:
        * MVC -- ASP.net--model view Controler,
        *MVVM --- Design ---model View Viewmodel    
    
        vi har Person class   ----skapa i den fil class PersonViewModel*/

