﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Orden
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public List<MateriasPrima> listMateriasPrimas { get; set; }
        public List<EmpleadosEtapas> EmpleadosEtapas { get; set; }
        public bool Estado { get; set; } = true; //abierta=true
        public string NombreOT { get; set; } = string.Empty;
        private enum EstadoOrden
        {
            Creada,
            EnEjecucion,
            Cancelada,
            Terminada
        }

        public int CantidadOrdenes=999;       

        public Orden(List<EmpleadosEtapas> empleadosEtapas, List<MateriasPrima> materiasPrimas,DateTime FechaInicio,string nombreOt)
        {
            EmpleadosEtapas = empleadosEtapas;
            listMateriasPrimas = materiasPrimas;
            this.FechaInicio = FechaInicio;
            this.NombreOT = nombreOt;

        }

        public Orden()
        {

        }

        public Orden(List<Orden> orden)
        {
            this.ListOrdenes = orden;
        }

        public List<Orden> ListOrdenes = new List<Orden>();

        
        /// <summary>
        /// verifica si se puede agregar la ot
        /// </summary>
        /// <returns></returns>
        public bool SePuedeAgregarOrden()
        {

            if (this.CantidadOrdenes > ListOrdenes.Count())
            {
                this.CantidadOrdenes = this.CantidadOrdenes - ListOrdenes.Count();
                return true;
            }
            else
            { return false; }

        }

        /// <summary>
        /// agrega una ot
        /// </summary>
        /// <param name="orden"></param>
        /// <returns></returns>

        public List<Orden> AgregarOrden(Orden orden)
        {
            ListOrdenes.Add(orden);

            return ListOrdenes;
        }
        /// <summary>
        /// caluca duracion de las ot
        /// </summary>
        /// <returns></returns>
        public decimal CalcularDuracionProducto()
        {
            decimal duracion = 0;
            foreach (var item in ListOrdenes)
            {
                foreach (var etapas in item.EmpleadosEtapas)
                {
                    duracion += etapas.Etapas.Duracion;
                }
            }
            return duracion;
        }
        /// <summary>
        /// calcula costo del producto
        /// </summary>
        /// <returns></returns>
        public decimal CalcularCostoProducto()
        {
            decimal costo = 0;
            foreach (var item in ListOrdenes)
            {
                foreach (var material in item.listMateriasPrimas)
                {
                    costo += material.Costo * material.Cantidad;
                }
            }
            return costo;
        }
        /// <summary>
        /// calcula la fecha de terminacion de cada OT de la lista de OT
        /// </summary>
        /// <returns></returns>
        public DateTime CalcularFechaProducto()
        {
            DateTime fecha = new DateTime();
            fecha = DateTime.Now;
            decimal duracion = 0;
            foreach (var item in ListOrdenes)
            {
                fecha = item.FechaInicio;

                foreach (var etapa in item.EmpleadosEtapas)
                {
                    duracion += etapa.Etapas.Duracion;
                }
                duracion /= 8;
            }
            fecha = fecha.AddDays(Convert.ToInt32(Math.Round(duracion, MidpointRounding.AwayFromZero)));

            return fecha;
        }
        /// <summary>
        /// calcula la asignacion por un puesto
        /// </summary>
        /// <param name="puesto"></param>
        /// <returns></returns>
        public Dictionary<Empleado, List<Procesos>> CalcularAsignacionPorPuesto(string puesto)
        {
            var diccionario = new Dictionary<Empleado, List<Procesos>>();

            foreach (var ordenes in ListOrdenes)
            {
                foreach (var etapas in ordenes.EmpleadosEtapas.Where(x => x.Empleado.Puesto.Nombre == puesto))
                {
                    var listaProcesos = new List<Procesos>();

                    var duracion = etapas.Etapas.Duracion;
                    var nombreProceso = etapas.Empleado.Nombre;
                    var fechinicio = ordenes.FechaInicio;

                    var proceso = new Procesos();
                    proceso.FechaDesde = fechinicio;
                    proceso.Nombre = nombreProceso;
                    decimal dias = Math.Floor(duracion / 8);
                    proceso.FechaHasta = duracion > 8 ? fechinicio.AddDays((int)Math.Truncate(dias)) : fechinicio;

                    if (!diccionario.ContainsKey(etapas.Empleado))
                    {

                        listaProcesos.Add(proceso);

                        diccionario.Add(etapas.Empleado, listaProcesos);
                    }
                    else
                    {
                        List<Procesos> lista = diccionario[etapas.Empleado];
                        lista.Add(proceso);
                        diccionario[etapas.Empleado] = lista;

                    }
                }
            }
            return diccionario;
        }
        /// <summary>
        /// Da la lista de empleados y de procesos que intervienen en un ot
        /// </summary>
        /// <param name="nombreOt"></param>
        /// <returns></returns>
        public Dictionary<List<Empleado>, List<Procesos>> CalcularEmpleadosPorOT(string nombreOt)
        {
            var dicconario = new Dictionary<List<Empleado>, List<Procesos>>();
            foreach (var item in this.ListOrdenes)
            {
                if(item.NombreOT.Equals(nombreOt))
                {
                    foreach(var p in item.EmpleadosEtapas)
                    {
                        decimal dias = Math.Floor(p.Etapas.Duracion / 8);
                        if (!dicconario.ContainsKey(new List<Empleado>() { p.Empleado }))
                        {
                            dicconario.Add(new List<Empleado>() { p.Empleado }, new List<Procesos>() { new Procesos() { Nombre = p.Etapas.Nombre, FechaDesde = item.FechaInicio, FechaHasta = item.FechaInicio.AddDays((int)Math.Truncate(dias)) } });
                        }
                        else
                        {
                            dicconario[new List<Empleado>() { p.Empleado }] = new List<Procesos>() { new Procesos() { Nombre = p.Etapas.Nombre, FechaDesde = item.FechaInicio, FechaHasta = item.FechaInicio.AddDays((int)Math.Truncate(dias)) } } ;
                        }
                    }
                }
            }
            return dicconario;
        }
        /// <summary>
        /// Te da el estado de la orden
        /// </summary>
        /// <returns></returns>
        public string GetEstadoOrden()
        {
            var fechaInicio = new DateTime();
            var fechaHasta = new DateTime();

            foreach (var orden in ListOrdenes)
            {
                fechaInicio = orden.FechaInicio;
                foreach(var etapas in orden.EmpleadosEtapas)
                {
                    var duracion = etapas.Etapas.Duracion;
                    fechaHasta = fechaInicio.AddDays((int)Math.Truncate(Math.Floor(duracion/8)));
                }
            }
            if(!Estado)
            {
                return EstadoOrden.Cancelada.ToString();
            }
            if (fechaInicio.Date>DateTime.Now.Date)
            {
                return EstadoOrden.Creada.ToString();
            }
            if(fechaInicio.Date>=DateTime.Now.Date && fechaHasta.Date>=DateTime.Now.Date)
            {
                return EstadoOrden.EnEjecucion.ToString();
            }
            else
            {
                return EstadoOrden.Terminada.ToString();
            }
        }
        /// <summary>
        /// calcula duracion con etapas en paralelo
        /// nesesita una lista de ORDENES
        /// </summary>
        /// <returns></returns>
        public DateTime CalcularDuracionConEtapasEnParalelo()
        {
            var fechaHasta = new DateTime();
            int cantDias = 0;
            foreach (var item in ListOrdenes)
            {
                var fechaInicio = new DateTime();
                fechaInicio = item.FechaInicio;
                foreach (var etapas in item.EmpleadosEtapas)
                {
                    if (!etapas.Etapas.EnParalelo)
                    {
                        fechaHasta = AgregarDiasLaborales(fechaInicio, (int)Math.Truncate(Math.Floor(etapas.Etapas.Duracion / 8)-1));
                    }
                    else
                    {
                        if ((int)Math.Truncate(Math.Floor(etapas.Etapas.Duracion / 8)) > cantDias)
                        { cantDias = (int)Math.Truncate(Math.Floor(etapas.Etapas.Duracion / 8)); }
                    }
                }
                fechaHasta = AgregarDiasLaborales(fechaHasta, cantDias);
            }
            return fechaHasta;
            
        }
        /// <summary>
        /// Agrega dias laborables a partir de una de determinada fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="CantDias"></param>
        /// <returns></returns>
        private DateTime AgregarDiasLaborales(DateTime fecha,int CantDias)
        {
            DateTime tmpDate = fecha;
            while (CantDias > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday )
                    CantDias--;
            }
            return tmpDate;
        }
    }
}
