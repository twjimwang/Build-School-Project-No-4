using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class CategoryViewModel
    {
        /// <summary>
        /// 此遊戲類別名稱封面照片
        /// </summary>
        public string GameCoverImg { get; set; }

        /// <summary>
        /// 此遊戲類別名稱
        /// </summary>
        public string GameTitle { get; set; }

        /// <summary>
        /// 類別ID
        /// </summary>
        public int CategroyId { get; set; }

        /// <summary>
        /// 全部遊戲
        /// </summary>
        public List<Game> GameAll { get; set; }
        /// <summary>
        /// 全部遊戲ID
        /// </summary>
        public class Game
        {
            public string GameName { get; set; }

            public int GameId { get; set; }
        }
    }
}