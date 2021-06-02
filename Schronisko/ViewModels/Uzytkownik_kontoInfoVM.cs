using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Schronisko.ViewModels
{
    public class Uzytkownik_kontoInfoVM 
    {
      
        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string pesel { get; set; }
        public string miasto { get; set; }
        public Nullable<int> kod_pocztowy { get; set; }
        public string ulica { get; set; }
        public string nr_mieszkania { get; set; }
        public string login { get; set; }
        public string haslo { get; set; }
        public int Uprawnienia_id { get; set; }

        

        

    }
}