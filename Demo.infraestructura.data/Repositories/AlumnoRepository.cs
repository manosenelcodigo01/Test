using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Demo.domain.Entities;
using Demo.domain.Interfaces.Repositories;
using Demo.infraestructura.data.Factory;
using Westwind.Utilities.Data;

namespace Demo.infraestructura.data.Repositories
{
   public class AlumnoRepository: DataWorker,IAlumnoRepository, ICursoRepository
    {
       public bool Add(Alumno t)
       {
            try
            {
                using (IDbConnection connection = dataBase.CreateOpenConnection())
                {
                    using (IDbCommand command = dataBase.CreateStoredProcCommand(@"usp_Alumno_add", connection))
                    {
                        IDataParameter param = command.CreateParameter();
                        param.ParameterName = "@dni";
                        param.Value = t.Dni;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@nombre";
                        param.Value = t.Nombre;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@apellido";
                        param.Value = t.Apellido;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@edad";
                        param.Value = t.Edad;
                        param.DbType = DbType.Int32;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@promedio";
                        param.Value = t.Promedio;
                        param.DbType = DbType.Decimal;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@idCurso";
                        param.Value = t.IdCurso;
                        param.DbType = DbType.Int32;
                        command.Parameters.Add(param);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
       }

       public List<Alumno> GetAll()
       {
           List<Alumno> alumnos;
           try
           {
                using (IDbConnection connection = dataBase.CreateOpenConnection())
                {
                    using (IDbCommand command = dataBase.CreateStoredProcCommand(@"usp_Alumno_list", connection))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            Mapper.CreateMap<IDataReader, Alumno>()
                                .ForMember(x => x.NombreCurso,
                                           o => o.MapFrom(s =>
                                           s.GetString(s.GetOrdinal("Descripcion"))
                                                )
                                           );
                            alumnos= Mapper.Map<IDataReader, List<Alumno>>(reader);
                        }
                    }
                }
            }
           catch (Exception e)
           {
              throw new Exception(e.Message);
           }
           return alumnos;
       }

       public Alumno GetById(int id)
       {
           Alumno alumno = null;
            try
            {
                using (var connection = dataBase.CreateOpenConnection())
                {
                    using (var command = dataBase.CreateStoredProcCommand(@"usp_Alumno_get", connection))
                    {
                        IDataParameter param = command.CreateParameter();
                        param.ParameterName = "@idAlumno";
                        param.Value = id;
                        param.DbType = DbType.Int32;
                        command.Parameters.Add(param);
                        using (var reader = command.ExecuteReader())
                        {
                            dynamic rd = new DynamicDataReader(reader);
                            if (rd.Read())
                            {
                                alumno = new Alumno()
                                {
                                    IdAlumno          = rd.IdAlumno,
                                    Nombre            = rd.Nombre,
                                    Apellido          = rd.Apellido,
                                    Dni               = rd.Dni,
                                    NombreCurso       = rd.Descripcion,
                                    IdCurso           = rd.IdCurso,
                                    Edad              = rd.Edad,
                                    Promedio          = rd.Promedio
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           return alumno;
       }

       public bool Update(Alumno t)
       {
            try
            {
                using (IDbConnection connection = dataBase.CreateOpenConnection())
                {
                    using (IDbCommand command = dataBase.CreateStoredProcCommand(@"usp_Alumno_update", connection))
                    {
                        IDataParameter param = command.CreateParameter();
                        param.ParameterName = "@dni";
                        param.Value = t.Dni;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@nombre";
                        param.Value = t.Nombre;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@apellido";
                        param.Value = t.Apellido;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@edad";
                        param.Value = t.Edad;
                        param.DbType = DbType.Int32;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@promedio";
                        param.Value = t.Promedio;
                        param.DbType = DbType.Decimal;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@idCurso";
                        param.Value = t.IdCurso;
                        param.DbType = DbType.Int32;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "@idAlumno";
                        param.Value = t.IdAlumno;
                        param.DbType = DbType.Int32;
                        command.Parameters.Add(param);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       public bool Remove(int id)
       {
           throw new NotImplementedException();
       }

       public List<Alumno> BuscarPorNombre(string nombre)
       {
           throw new NotImplementedException();
       }

       public List<Curso> ListarCursos()
       {
            List<Curso> cursos;
            try
            {
                using (IDbConnection connection = dataBase.CreateOpenConnection())
                {
                    using (IDbCommand command = dataBase.CreateStoredProcCommand(@"usp_Curso_list", connection))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            Mapper.CreateMap<IDataReader, Curso>();
                            cursos = Mapper.Map<IDataReader, List<Curso>>(reader);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return cursos;
        }
    }
}
