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
    
    public partial class uprawnienia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public uprawnienia()
        {
            this.konto_info = new HashSet<konto_info>();
        }
    
        public int id { get; set; }
        public string nazwa { get; set; }
        public string opis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<konto_info> konto_info { get; set; }
    }
}
