using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using API.Data;
using API.DTOs.Stock;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public StockController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _applicationDBContext.Stock.ToList().Select(s => s.ToStockDto());
            return Ok(stocks);
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _applicationDBContext.Stock.Find(id);


            if (stock == null)
            {
                return NotFound();
            };
            return Ok(stock);
        }




        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDTO)
        {
            var StockModel = stockDTO.ToStockFromCreateDto();
            _applicationDBContext.Stock.Add(StockModel);
            _applicationDBContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = StockModel.Id }, StockModel);
        }




        [HttpPut]
        [Route("{id}")]

        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockDTO UpdateStockDTO)
        {
            var StockModel = _applicationDBContext.Stock.FirstOrDefault(x => x.Id == id);


            if (StockModel == null)
            {
                return NotFound();
            };

            StockModel.Symbol = UpdateStockDTO.Symbol;
            StockModel.CompanyName = UpdateStockDTO.CompanyName;
            StockModel.Purchase = UpdateStockDTO.Purchase;
            StockModel.LastDiv = UpdateStockDTO.LastDiv;
            StockModel.Industry = UpdateStockDTO.Industry;
            StockModel.MarketCap = UpdateStockDTO.MarketCap;



            _applicationDBContext.SaveChanges();
            return Ok(StockModel.ToStockDto());
        }


        [HttpDelete]
        [Route("{id}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var StockModel = _applicationDBContext.Stock.FirstOrDefault(x => x.Id == id);
            if (StockModel == null)
            {
                return NotFound();
            };

            _applicationDBContext.Remove(StockModel);
            _applicationDBContext.SaveChanges();
            return NoContent();


        }

    }
}