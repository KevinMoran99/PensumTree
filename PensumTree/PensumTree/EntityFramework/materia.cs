    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PensumTree.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class materia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public materia()
        {
            this.materia1 = new HashSet<materia>();
            this.materia11 = new HashSet<materia>();
            this.materia12 = new HashSet<materia>();
            this.materia13 = new HashSet<materia>();
            this.pensums = new HashSet<pensum>();
        }
    
        public long id { get; set; }
        public string nombre { get; set; }
        public long uv { get; set; }
        public string codigo { get; set; }
        public bool primerCiclo { get; set; }
        public bool segundoCiclo { get; set; }
        public bool lab { get; set; }
        public bool electiva { get; set; }
        public long idEscuela { get; set; }
        public Nullable<long> idPrerreq1 { get; set; }
        public Nullable<long> idPrerreq2 { get; set; }
        public Nullable<long> idPrerreq3 { get; set; }
        public Nullable<long> idPrerreq4 { get; set; }
        public bool estado { get; set; }
    
        public virtual escuela escuela { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<materia> materia1 { get; set; }
        public virtual materia materia2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<materia> materia11 { get; set; }
        public virtual materia materia3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<materia> materia12 { get; set; }
        public virtual materia materia4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<materia> materia13 { get; set; }
        public virtual materia materia5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pensum> pensums { get; set; }
    }
}
