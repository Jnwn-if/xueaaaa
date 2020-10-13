using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET200703.ZSGC.ViewModel
{
    public class GameViewModel
    {
        [DisplayName("编号")]
        
        public int id { get; set; }

        [DisplayName("游戏类型")]
        [Required(ErrorMessage = "请输入游戏类型")]
        public int gTid { get; set; }

        [DisplayName("游戏厂商")]
        [Required(ErrorMessage = "请输入游戏厂商")]
        public int gSid { get; set; }

        [DisplayName("名称")]
        [Required(ErrorMessage = "请输入游戏名称")]
        public string gName { get; set; }

        [DisplayName("价格")]
        [Required(ErrorMessage = "请输入价格")]
        public double gPrice { get; set; }

        [DisplayName("上架状态")]
        [Required(ErrorMessage = "请选择上架状态")]
        public bool gState { get; set; }
    }
}