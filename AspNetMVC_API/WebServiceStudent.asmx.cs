using AspNetMVC_API_BLL.Repository;
using AspNetMVC_API_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AspNetMVC_API
{
    /// <summary>
    /// Summary description for WebServiceStudent
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceStudent : System.Web.Services.WebService
    {
        //Global alan
        StudentRepo myStudentRepo = new StudentRepo();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Student> GetAll()
        {
            try
            {
                List<Student> list = myStudentRepo.GetAll();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public string Insert(string name, string surname)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                {
                    throw new Exception("name surname alanlarına mutlaka veri girilmelidir!");
                }
                Student newStudent = new Student()
                {
                    Name=name,
                    Surname=surname
                };
                int insertResult = myStudentRepo.Insert(newStudent);
                if (insertResult>0)
                {
                    //Birinci yöntem
                    return "kayıt başarılı olarak eklendi. id = " + newStudent.Id;
                }
                else
                {
                    throw new Exception("Kayıt ekleme işleminde beklenmedik bir hata oluştu!");
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
