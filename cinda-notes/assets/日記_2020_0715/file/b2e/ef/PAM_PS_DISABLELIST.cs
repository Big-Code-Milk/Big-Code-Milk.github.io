//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mxic.ITC.PAM.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAM_PS_DISABLELIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAM_PS_DISABLELIST()
        {
            this.PAM_PS_DISABLELIST_DETAIL = new HashSet<PAM_PS_DISABLELIST_DETAIL>();
        }
    
        public Nullable<decimal> SIGN_FORM_ID { get; set; }
        public Nullable<System.DateTime> CLOSE_DATE { get; set; }
        public string SIGNER_EMPNO { get; set; }
        public string DISABLE_DESC { get; set; }
        public decimal ID { get; set; }
        public Nullable<decimal> STATUS { get; set; }
        public string SIGNER_NAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAM_PS_DISABLELIST_DETAIL> PAM_PS_DISABLELIST_DETAIL { get; set; }
        public virtual SIGN_FORM_MAIN SIGN_FORM_MAIN { get; set; }
    }
}
