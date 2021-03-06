﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class Advertisement : BaseEntity
    {

        
        public string Title
        {
            set;
            get;
        }
        public string Description
        {
            set;
            get;
        }
       
        public decimal price
        {
            get;
            set;

        }

        public Category Category
        {
            set;
            get;
        }
        //public long CategoryId
        //{
        //    set;
        //    get;
        //}

        public bool IsActive
        {
            set;
            get;

        }

       
        public Local Local
        {
            set;
            get;
        }

        public long LocalId
        {
            set;
            get;
        }
        public InnerCategory InnerCategory
        {
            get;
            set;
        }
        public long InnerCategoryId
        {
            set;
            get;
        }
        public List<Image> Images { get; set; }


        [NotMapped]
        public string SelectedImage
        {
            get;
            set;

        }

    }
    


}
