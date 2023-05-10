using BYLLQ0_HFT_2022232.Logic;
using BYLLQ0_HFT_2022232.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace BYLLQ0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {

        ILabelLogic logic;
        public LabelController(ILabelLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Label> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Label Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Label value)
        {
            this.logic.Create(value);
        }
 

        [HttpPut]
        public void Update([FromBody] Label value)
        {
            this.logic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            this.logic.Delete(id);
        }
        [HttpGet("LabelsWithMostAlbums")]
        public IEnumerable<NonCrud.LabelInfo> GetLabelsWithMostAlbums()
        {
            return this.logic.GetLabelsWithMostAlbums();
        }


    }
}
