
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Data.SQLite;


namespace presevi_cms.Models
{
    public class contentManage
    {
        public List<BannerClientileModel> contentList = new List<BannerClientileModel>();

        public List<BannerClientileModel> getContent(string contentType)
        {
            var content = contentList.FindAll(a => a.ContentType == contentType)
                .OrderBy(a => a.Sequence).ToList();
            return content;
        }
    }

    
    
}