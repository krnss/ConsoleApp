using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Interfase
{
    public interface IProduct
    {
        int ID { get; set; }
        string Name { get; set; }
        string Autor { get; set; }
        float Prise { get; set; }
        string UrlFoto { get; set; }
    }
}
