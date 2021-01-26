using GameShop.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.Models
{
    public class Game : IProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }
        public float Prise { get; set; }
        public string UrlFoto { get; set; } 

        public Game(int Id,string name, string autor, float prise,string urlFoto)
        {
            this.ID = Id;
            this.Name = name;
            this.Autor = autor;
            this.Prise = prise;
            this.UrlFoto = urlFoto;
        }
        public Game(string name, string autor, float prise,string urlFoto)
        {            
            this.Name = name;
            this.Autor = autor;
            this.Prise = prise;
            this.UrlFoto = urlFoto;
        }
        public Game()
        {
            
        }

        public override string ToString()
        {
            return $"name {Name}\nautor {Autor}\nprise {Prise}";
        }
    }
}