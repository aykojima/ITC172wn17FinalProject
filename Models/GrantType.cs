//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GrantType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GrantType()
        {
            this.GrantRequest = new HashSet<GrantRequest>();
        }
    
        public int GrantTypeKey { get; set; }
        public string GrantTypeName { get; set; }
        public decimal GrantTypeMaximum { get; set; }
        public decimal GrantTypeLifetimeMaximum { get; set; }
        public string GrantTypeDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrantRequest> GrantRequest { get; set; }
    }
}
