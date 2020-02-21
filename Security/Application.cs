//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Security
{
    using System;
    using System.Collections.Generic;
    
    public partial class Application
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Application()
        {
            this.ApplicationAccess = new HashSet<ApplicationAccess>();
        }
    
        public int ApplicationId { get; set; }
        public int AccessEntityId { get; set; }
        public string ApplicationTag { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreationDt { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime LastModDt { get; set; }
        public string LastModBy { get; set; }
        public Nullable<int> ParentId { get; set; }
    
        public virtual AccessEntity AccessEntity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationAccess> ApplicationAccess { get; set; }
    }
}
