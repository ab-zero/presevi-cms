
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
        public List<PreseviDataModel> contentList = new List<PreseviDataModel>();

        public List<PreseviDataModel> getContent(string contentType)
        {
            var content = contentList.FindAll(a => a.ContentType == contentType)
                .OrderBy(a => a.Sequence).ToList();
            return content;
        }
    }

    
    
}