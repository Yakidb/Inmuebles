using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.DAO;
using API.DATA;
using API.DTO;
using API.Helpers;
using API.Models;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [RoutePrefix("api/inmuebles")]
    public class inmueblesController : ApiController
    {
        private InmueblesDbContext context_Z = new InmueblesDbContext();
        private inmueblesDAO InmueblesDAO_Z;

        //                                                  //All inmuebles
        [HttpGet]
        [Route("GetInmuebles")]
        public async Task<IHttpActionResult> GetInmuebles()
        {
            this.InmueblesDAO_Z = new inmueblesDAO(context_Z);
            List<inmueblesDto> inmueblesDtos = this.InmueblesDAO_Z.GetAllRecords();

            return Ok(inmueblesDtos);
        }

        //                                                  //Obtener inmueble por Id
        [HttpGet]
        [Route("GetInmueble/{id:int}")]
        public async Task<IHttpActionResult> GetInmueble(int id)
        {
            this.InmueblesDAO_Z = new inmueblesDAO(context_Z);
            inmueblesDto inmueblesDto = this.InmueblesDAO_Z.GetRecordById(id);
            if (inmueblesDto == null)
            {
                return NotFound();
            }
            return Ok(inmueblesDto);
        }

        //                                                  //Agregar inmueble
        [HttpPost]
        [Route("CreateInmueble")]
        public async Task<IHttpActionResult> PostInmueble(inmueblesDto inmueblesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            RcdoperEnum rcdoper = RcdoperEnum.Z_NULL;

            this.InmueblesDAO_Z = new inmueblesDAO(context_Z);
            this.InmueblesDAO_Z.subAddProducto(inmueblesDto, out rcdoper);

            HttpResponseMessage responseMessage;
            if (
                rcdoper == RcdoperEnum.SUCESS
                )
            {
                 responseMessage = new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            

            return ResponseMessage(responseMessage);
        }

    }
}