//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EncuestasWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoDocumentoDigital
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoDocumentoDigital()
        {
            this.DocumentosDigitales = new HashSet<DocumentosDigitale>();
        }
    
        public int id { get; set; }
        public string NombreTipoDoc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentosDigitale> DocumentosDigitales { get; set; }
    }
}
