using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET200703.ZSGC.DTOModel
{
    /// <summary>
    /// 返回信息
    /// </summary>
    public class ResultModel
    {
        /// <summary>
        /// 行为是否通过
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 信息提示
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}