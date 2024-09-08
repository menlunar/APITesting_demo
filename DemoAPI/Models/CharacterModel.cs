using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System;

namespace DemoAPI.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birth_Year { get; set; }
        public string Eye_Color { get; set; }
        public string Gender { get; set; }
        public string Hair_Color { get; set; }
        public double Height { get; set; }
        public double Mass { get; set; }
        public string HomeWorld { get; set; }
        //public string[] Films { get; set; }
        //public string[] Species { get; set; }
        //public string[] Starships { get; set; }
        //public string[] Vehicles { get; set; }
        public string URL { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
    }



    //    name string -- The name of this person.
    //birth_year string -- The birth year of the person, using the in-universe standard of BBY or ABY - Before the Battle of Yavin or After the Battle of Yavin.The Battle of Yavin is a battle that occurs at the end of Star Wars episode IV: A New Hope.
    //    eye_color string -- The eye color of this person.Will be "unknown" if not known or "n/a" if the person does not have an eye.
    //gender string -- The gender of this person.Either "Male", "Female" or "unknown", "n/a" if the person does not have a gender.
    //hair_color string -- The hair color of this person.Will be "unknown" if not known or "n/a" if the person does not have hair.
    //height string -- The height of the person in centimeters.
    //mass string -- The mass of the person in kilograms.
    //skin_color string -- The skin color of this person.
    //homeworld string -- The URL of a planet resource, a planet that this person was born on or inhabits.
    //films array -- An array of film resource URLs that this person has been in.
    //species array -- An array of species resource URLs that this person belongs to.
    //    starships array -- An array of starship resource URLs that this person has piloted.
    //    vehicles array -- An array of vehicle resource URLs that this person has piloted.
    //url string -- the hypermedia URL of this resource.
    //created string -- the ISO 8601 date format of the time that this resource was created.
    //edited string -- the ISO 8601 date format of the time that this resource was edited.
}
