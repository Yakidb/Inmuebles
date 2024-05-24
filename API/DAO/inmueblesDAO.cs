//                                                          //AUTHOR: Towa (EFA-Eliakim Flores).
//                                                          //CO-AUTHOR: Towa ().
//                                                          //DATE: May 7, 2023. 

using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System;
using API.DATA;
using Microsoft.Extensions.Logging;
using API.Models;
using API.DTO;
using System.Data.Entity;
using System.Linq;
using API.Helpers;

namespace API.DAO
{
    //==================================================================================================================
    public class inmueblesDAO
    {
        //--------------------------------------------------------------------------------------------------------------
        //                                                  //This is a Data Access Object (DAO)

        //--------------------------------------------------------------------------------------------------------------
        /*CONSTANTS*/

        //--------------------------------------------------------------------------------------------------------------
        /*INITIALIZER*/

        //--------------------------------------------------------------------------------------------------------------
        /*INSTANCE VARIABLES*/

        private readonly InmueblesDbContext context_Z;

        //--------------------------------------------------------------------------------------------------------------
        /*COMPUTED VARIABLES*/

        //--------------------------------------------------------------------------------------------------------------
        /*METHODS TO SUPPORT COMPUTED VARIABLES*/

        //-------------------------------------------------------------------------------------------------------------
        /*OBJECT CONSTRUCTORS*/

        //-------------------------------------------------------------------------------------------------------------
        public inmueblesDAO(
            InmueblesDbContext context
            )
        {
            this.context_Z = context;
        }

        //-------------------------------------------------------------------------------------------------------------
        /*TRANSFORMATION METHODS*/
        
        //-------------------------------------------------------------------------------------------------------------
        public void subAddProducto(
            //                                              //Agregar inmueble a base de datos
            inmueblesDto inmuebleDto,
            out RcdoperEnum rcdoper
            )
        {

            try
            {
                inmentInmueblesEntityDB inmueblesEntityDB = new inmentInmueblesEntityDB();
                inmueblesEntityDB.Nombre = inmuebleDto.Nombre;
                inmueblesEntityDB.Direccion = inmuebleDto.Direccion;
                inmueblesEntityDB.Telefono = inmuebleDto.Telefono;
                inmueblesEntityDB.CapacidadAforo = inmuebleDto.CapacidadAforo;
                 this.context_Z.Inmuebles.Add(inmueblesEntityDB);
                 this.context_Z.SaveChanges();
                 rcdoper = RcdoperEnum.SUCESS;  
            }
            catch (Exception ex)
            {
                rcdoper = RcdoperEnum.UNKNOWN_ERROR;
            }

        }

        /*
        //--------------------------------------------------------------------------------------------------------------
        public bool boolIsValidEntity(
            //                                              //Validar campos de la entity mediante reglas de negocio
            prodentityProductoEntityDB prodEntity_I,
            out RcdoperEnum rcdoperEnum_I,
            out string strMensajeCustomizado_IO
            )
        {
            strMensajeCustomizado_IO = " ";
            rcdoperEnum_I = RcdoperEnum.Z_NULL;
            proventityProveedorEntityDB? provEntityExistente = null;

            if (!decimal.TryParse(prodEntity_I.Costo.ToString(), out _))
            {
                strMensajeCustomizado_IO = "El costo debe ser un valor decimal.";
                this.logger_Z.LogWarningWrapped(BorderEnum.BorderBoth, typeof(ProductosDao),
                    strMensajeCustomizado_IO, "*");
                rcdoperEnum_I = RcdoperEnum.FIELD_INVALID;
                return false;
            }

            return true;
        }*/

        //--------------------------------------------------------------------------------------------------------------
        //                                                  //ACCESS METHODS.

        //--------------------------------------------------------------------------------------------------------------
        public inmueblesDto GetRecordById(
            //                                              //Encontrar inmueble por ID
            int? id_I
            )
        {
            inmentInmueblesEntityDB inmentity = null;
            inmueblesDto inmueblesDto = null;
            try
            {

                if (
                    id_I.Value != null
                    )
                {
                    inmentity = this.context_Z.Inmuebles
                    .FirstOrDefault(t => t.ID == id_I);
                    if (inmentity != null)
                    {
                        return inmueblesDto =
                            new inmueblesDto(inmentity.ID, inmentity.Nombre, inmentity.Direccion, inmentity.Telefono, inmentity.CapacidadAforo);
                    }
                    else
                    {
                        return inmueblesDto = null;
                    }
                }
                else
                {
                    return inmueblesDto = null;
                }

            }
            catch (Exception ex)
            {
                //                                          //Problema interno, return objeto en null
                return inmueblesDto = null;
            }
        }

        //--------------------------------------------------------------------------------------------------------------
        public List<inmueblesDto> GetAllRecords()
        {
            List<inmueblesDto> inmueblesDto;
            try
            {
                List<inmentInmueblesEntityDB> inmueblesEntities = context_Z.Inmuebles.ToList();

                //                                              //Mappeo
                inmueblesDto = inmueblesEntities.Select(entity =>
                new inmueblesDto(entity.ID, entity.Nombre, entity.Direccion, entity.Telefono, entity.CapacidadAforo)).ToList();

                return inmueblesDto;
            }
            catch (Exception ex)
            {
                return inmueblesDto = new List<inmueblesDto>();
            }
            
        }


        //-------------------------------------------------------------------------------------------------------------
    }
    //==================================================================================================================
}
/*END-TASK*/