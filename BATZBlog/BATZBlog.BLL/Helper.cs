using BATZBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATZBlog.BLL
{
    class Helper
    {
        public static Response<T> SetIfElse<T>( bool isValid, string onSuccessMessage = "", string onFailureMessage = "" )
        {
            Response<T> response = new Response<T>( );

            if(isValid)
            {
                response.Success = true;
                response.Message = onSuccessMessage;
            }
            else
            {
                response.Success = false;
                response.Message = onFailureMessage;
            }
            return response;
        }
    }
}