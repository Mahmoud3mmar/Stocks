using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using API.DTOs.Stock;
using API.Models;

namespace API.Mappers
{
    public static class StockMappers
    {
        public static Stock_DTO ToStockDto(this Stock StockModel)
        {
            return new Stock_DTO
            {
                Id = StockModel.Id,
                Symbol = StockModel.Symbol,
                CompanyName = StockModel.CompanyName,
                LastDiv = StockModel.LastDiv,
                Industry = StockModel.Industry,
                MarketCap = StockModel.MarketCap


            };
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto CreateStockDTO)
        {
            return new Stock
            {
                Symbol = CreateStockDTO.Symbol,
                CompanyName = CreateStockDTO.CompanyName,
                LastDiv = CreateStockDTO.LastDiv,
                Industry = CreateStockDTO.Industry,
                MarketCap = CreateStockDTO.MarketCap


            };
        }



    }



}