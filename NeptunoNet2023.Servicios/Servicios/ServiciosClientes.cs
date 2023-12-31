﻿using NeptunoNet2023.Comun.Interfaces;
using NeptunoNet2023.DatosSql;
using NeptunoNet2023.Entidades.Dtos.Ciudad;
using NeptunoNet2023.Entidades.Dtos.Cliente;
using NeptunoNet2023.Entidades.Entidades;
using NeptunoNet2023.Servicios.Interfaces;

namespace NeptunoNet2023.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly IRepositorioClientes _repositorioClientes;
        public ServiciosClientes()
        {
            _repositorioClientes = new RepositorioClientes();
        }

        public int Borrar(Cliente cliente)
        {
            try
            {
                return _repositorioClientes.Borrar(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Cliente cliente)
        {
            try
            {
                return _repositorioClientes.EstaRelacionado(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                return _repositorioClientes.Existe(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteListDto GetClienteDtoPorId(int clienteId)
        {
            try
            {
                return _repositorioClientes.GetClienteDtoPorId(clienteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Cliente GetClientePorId(int clienteId)
        {
            try
            {
                return _repositorioClientes.GetClientePorId(clienteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClienteListDto> GetClientes(Pais paisFiltro=null, CiudadComboDto ciudadFiltro=null)
        {
            try
            {
                return _repositorioClientes.GetClientes(paisFiltro,ciudadFiltro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Guardar(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == 0)
                {
                    return _repositorioClientes.Agregar(cliente);

                }
                else
                {
                    return _repositorioClientes.Editar(cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
