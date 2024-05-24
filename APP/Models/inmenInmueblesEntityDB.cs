using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//                                                          //AUTHOR: EFA-Eliakim Flores.
//                                                          //CO-AUTHOR: .
//                                                          //DATE: May 23, 2024.

namespace APP.Models
{
    [Table("Inmuebles")]
    //==================================================================================================================
    public class inmentInmueblesEntityDB
    {
        //--------------------------------------------------------------------------------------------------------------
        /*PRIMARY KEY*/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //--------------------------------------------------------------------------------------------------------------
        /*COLUMNS*/
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int CapacidadAforo { get; set; }

        //--------------------------------------------------------------------------------------------------------------
    }

    //==================================================================================================================
}
/*END-TASK*/