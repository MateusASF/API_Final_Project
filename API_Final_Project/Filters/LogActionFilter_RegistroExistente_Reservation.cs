﻿using API_Final_Project.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Final_Project.Filters
{
    public class LogActionFilter_RegistroExistente_Reservation : ActionFilterAttribute
    {
        IEventReservationService _eventReservationService;

        public LogActionFilter_RegistroExistente_Reservation(IEventReservationService eventReservationService)
        {
            _eventReservationService = eventReservationService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long idReservation = (long)context.ActionArguments["id"];

            if (_eventReservationService.ConsultarReservasId(idReservation) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }

    }
}