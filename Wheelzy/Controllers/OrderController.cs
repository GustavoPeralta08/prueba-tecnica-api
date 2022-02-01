using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Interfaces;
using Wheelzy.Model.DTO;
using Wheelzy.Model.Entites;

namespace Wheelzy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost("AddOrderWithDetail")]
        public async Task<IActionResult> AddOrderWithDetail(RequestOrderAdd newRequestOrder)
        {
            OrderDto orderDto = new OrderDto();
            orderDto.DateOrder = DateTime.ParseExact(newRequestOrder.DateOrder, "dd/MM/yyyy HH:mm:ss", null);
            orderDto.CantProduct = newRequestOrder.CantProduct;
            orderDto.TotalAmount = newRequestOrder.TotalAmount;

            var order = _mapper.Map<Order>(orderDto);

            await _orderService.InsertOrder(order);
            await _orderService.InsertOrderDetail(order.OrderId, newRequestOrder.OrderDetail);
            
            return Ok(new { mesagge = "Se ha creado con exito" });
        }

        [HttpGet("GetListOrderWithDetail")]
        public ActionResult<List<OrderWithDetail>> GetListOrderWithDetail()
        {
            var response = _orderService.GetOrdersWithDetail();
            return Ok(response);
        }

    }
}
