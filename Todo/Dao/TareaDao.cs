using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Todo.Models;
using Todo.Utils;

namespace Todo.Dao
{
    public class TareaDao: ConexionDB
    {
        StructureResponse _struct = new StructureResponse();
        public async Task<StructureResponse> ListTarea()
        {
            var listar = new List<Tarea>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SPListarTarea", con))
                {                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            _struct.code = reader.GetString(0);
                            _struct.message = reader.GetString(1);
                            _struct.messageTitle = reader.GetString(2);
                            if (_struct.code == "1")
                            {
                                Tarea item = new Tarea();
                                item.idTarea = reader.GetInt32(3);
                                item.titulo = reader.GetString(4);
                                item.detalle = reader.GetString(5);
                                item.estado = reader.GetBoolean(6);
                                listar.Add(item);
                            }
                        }
                    }
                    con.Close();
                }
                _struct.payload = listar;
            }
            catch (Exception ex)
            {
                _struct.code = "0"; _struct.message = ex.Message; _struct.messageTitle = "(Error de excepción)";
            }
            return _struct;
        }

        public async Task<StructureResponse> AddTarea(Tarea data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SPAgregarTarea", con))
                {
                    cmd.Parameters.AddWithValue("@titulo", data.titulo);
                    cmd.Parameters.AddWithValue("@detalle", data.detalle);                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            _struct.code = reader.GetString(0);
                            _struct.message = reader.GetString(1);
                            _struct.messageTitle = reader.GetString(2);
                        }

                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _struct.code = "0"; _struct.message = ex.Message; _struct.messageTitle = "(Error de excepción)";
            }
            return _struct;
        }

        public async Task<StructureResponse> UpdateTarea(Tarea data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SPActualizarTarea", con))
                {
                    cmd.Parameters.AddWithValue("@idTarea", data.idTarea);
                    cmd.Parameters.AddWithValue("@titulo", data.titulo);
                    cmd.Parameters.AddWithValue("@detalle", data.detalle);
                    cmd.Parameters.AddWithValue("@estado", data.estado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            _struct.code = reader.GetString(0);
                            _struct.message = reader.GetString(1);
                            _struct.messageTitle = reader.GetString(2);
                        }

                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _struct.code = "0"; _struct.message = ex.Message; _struct.messageTitle = "(Error de excepción)";
            }
            return _struct;
        }

        public async Task<StructureResponse> DeleteTarea(Tarea data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SPEliminarTarea", con))
                {
                    cmd.Parameters.AddWithValue("@idTarea", data.idTarea);
                    cmd.Parameters.AddWithValue("@titulo", data.titulo);                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            _struct.code = reader.GetString(0);
                            _struct.message = reader.GetString(1);
                            _struct.messageTitle = reader.GetString(2);
                        }

                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _struct.code = "0"; _struct.message = ex.Message; _struct.messageTitle = "(Error de excepción)";
            }
            return _struct;
        }
    }
}