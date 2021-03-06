﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class AdvertisementViewModel
    {
        public long Id { get; set; }


        [Required(ErrorMessage = "وارد کردن عنوان ضروری  است ")]
        public string Title
        { set; get; }


        public string Description
        { set; get; }

        public decimal price
        { set; get; }

        public Category Category
        { set; get; }
        //public long CategoryId
        //{
        //    set;
        //    get;
        //}

        public bool IsActive
        { set; get; }

        
        public Local Local
        { set; get; }

        [Required(ErrorMessage = "لطفا دسته بندی مورد نظر را انتخاب کنید ")]
        public long LocalId
        { set; get; }

       
        public InnerCategory InnerCategory
        { set; get; }

        [Required(ErrorMessage = "لطفا دسته بندی مورد نظر را انتخاب کنید ")]
        public long InnerCategoryId
        { set; get; }

        public List<Image> Images { get; set; }

        [NotMapped]
        public string SelectedImage
        { set; get; }
        public DateTime? UpdatedDate { set; get; }

        public DateTime CreateDate { set; get; }

    }

}

