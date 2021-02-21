using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using MySql.Data.MySqlClient;
using Geek_Inside.Models.db;

namespace Geek_Inside.Models
{

    public class AdminModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Contenido { get; set; }
        public string Url_img { get; set; }
        public string Create_on { get; set; }

        public List<AdminModel> Consulta(int? id = null)
        {
            using(var cn = Connection.Connect())
            {
                string sql = "SELECT * FROM publicaciones ";
                if(id != null)
                {
                    sql += "WHERE id = '"+id+"'; ";
                }
                return cn.Query<AdminModel>(sql).ToList(); 
            }
        }

        public bool Insertar(AdminModel model)
        {
            using (var cn = Connection.Connect())
            {
                string sql = "INSERT INTO publicaciones (titulo, autor, contenido,url_img,created_on) VALUES('"+model.Titulo+"','"+model.Autor+"',,'" +model.Contenido +"','" +model.Url_img+"',NOW())";
                if(cn.Execute(sql) >0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            using (var cn = Connection.Connect()) {
                string sql = "DELETE FROM publicaciones WHERE id = '" + id + "'";
                if (cn.Execute(sql)>0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool Actualizar(AdminModel model)
        {
            using (var cn = Connection.Connect())
            {
                string sql = "UPDATE publicaciones SET titulo = '" + model.Titulo + "', autor ='" + model.Autor + "', contenido = '" + model.Contenido + "' ,url_img '" + model.Url_img + "',created_on = NOW() WHERE id = '"+model.Id+"' ";
                if (cn.Execute(sql) > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}