﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RasorSample.Model
{
    public class Writing
    {
        //データベース上のキー
        public int ID { get; set; }

        //投稿者名
        public string Name { get; set; }

        //投稿内容
        public string Comment { get; set; }

        //投稿日時
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
