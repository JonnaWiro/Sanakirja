//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sanakirja.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Sanasto
    {
        public int SanastoId { get; set; }
        [Required(ErrorMessage = "Pakollinen kentt�.")]
        public string SuomiTermi { get; set; }
        [Required(ErrorMessage = "Pakollinen kentt�.")]
        public string EnglantiTermi { get; set; }
        [Required(ErrorMessage = "Pakollinen kentt�.")]
        public string Selite { get; set; }
        public string VideoLink { get; set; }
        public string LiittyvatTermit { get; set; }
    }
}
