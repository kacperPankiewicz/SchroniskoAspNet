//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schronisko
{
    using System;
    using System.Collections.Generic;
    
    public partial class historia_adopcji
    {
        public int id { get; set; }
        public System.DateTime data { get; set; }
        public int Zwierze_id { get; set; }
        public int Uzytkownik_id { get; set; }
        public int Pracownik_id { get; set; }
    
        public virtual pracownik pracownik { get; set; }
        public virtual uzytkownik uzytkownik { get; set; }
        public virtual zwierze zwierze { get; set; }
    }
}