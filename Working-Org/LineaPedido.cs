//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Working_Org
{
    using System;
    using System.Collections.Generic;
    
    public partial class LineaPedido
    {
        public long Id { get; set; }
        public long IdPedido { get; set; }
        public long IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Pendiente { get; set; }
        public string Otro { get; set; }
    }
}
