using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AspNetMVC_API.Models.ViewModels;
using AspNetMVC_API_BLL.Repository;
using AspNetMVC_API_Entity.Models;

namespace AspNetMVC_API.Controllers
{
    public class StudentController : ApiController
    {
        //Global alan
        StudentRepo myStudentRepo = new StudentRepo();

        public ResponseData GetAll()
        {
            try
            {
                var list = myStudentRepo.GetAll().Select(x=>
                new 
                { 
                    x.Id,
                    x.Name,
                    x.Surname,
                    x.RegisterDate
                }).ToList();
                if (list!=null)
                {
                    if (list.Count==0)
                    {
                        return new ResponseData()
                        {
                            Success = true,
                            Message = "Sistemde kayıtlı öğrenci bulunmamaktadır.",
                            Data = list
                        };
                    }
                    return new ResponseData()
                    {
                        Success=true,
                        Message="Tüm öğrencilerin listesi başarıyla gönderildi.",
                        Data=list
                    };
                }
                else
                {
                    return new ResponseData()
                    {
                        Success = false,
                        Message = "Tüm öğrenciler getirilirken bir hata oluştu!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseData()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public ResponseData GetById(int id)
        {
            try
            {
                if (id>0)
                {
                    var student = myStudentRepo.GetById(id);
                    if (student==null)
                    {
                        throw new Exception($"{id} değerinde bir kayıt bulunamadı!");
                    }
                    return new ResponseData()
                    {
                        Success=true,
                        Message="Kayıt bulundu.",
                        Data= new
                        {
                            student.Id,
                            student.Name,
                            student.Surname,
                            student.RegisterDate
                        }
                    };
                }
                else
                {
                    return new ResponseData()
                    {
                        Success = false,
                        Message = "Negatif değer gönderilemez!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseData()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}