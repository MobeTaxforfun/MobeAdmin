using Microsoft.AspNetCore.Mvc;
using MobeAdmin.Domain.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobeAdmin.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 回應成功(有物件)
        /// </summary>
        /// <typeparam name="T">型態</typeparam>
        /// <param name="data">回傳結果</param>
        /// <param name="message">提示</param>
        /// <returns></returns>
        [NonAction]
        public BaseMessageAPI<T> Success<T>(T data, string message = "操作成功")
        {
            return new BaseMessageAPI<T>()
            {
                Success = true,
                Message = message,
                Data = data,
            };
        }

        /// <summary>
        /// 回應成功(無物件)
        /// </summary>
        /// <param name="message">提示</param>
        /// <returns></returns>
        [NonAction]
        public BaseMessageAPI Success(string message = "操作成功")
        {
            return new BaseMessageAPI()
            {
                Success = true,
                Message = message,
            };
        }

        /// <summary>
        /// 回應失敗(無物件)
        /// </summary>
        /// <param name="message">提示</param>
        /// <returns></returns>
        [NonAction]
        public BaseMessageAPI<T> Failed<T>(T data, string message = "操作失敗")
        {
            return new BaseMessageAPI<T>()
            {
                Success = false,
                Message = message,
                Data = data
            };
        }

        [NonAction]
        public BaseMessageAPI Failed(string message = "操作失敗")
        {
            return new BaseMessageAPI()
            {
                Success = false,
                Message = message,
            };
        }

    }
}
