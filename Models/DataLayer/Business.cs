using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace presevi_cms.Models.DataLayer
{
    public class Business
    {
        private DataAccess dataAccess = null;
        public Business()
        {
            dataAccess = new DataAccess();
        }

        public List<PreseviDataModel> GetContent(string contentType){
            List<PreseviDataModel> lstContent = new List<PreseviDataModel>();
            using (DataSet ds = dataAccess.GetData(contentType))
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        PreseviDataModel content = new PreseviDataModel()
                        {
                            
                            Id = Helper.ConvertToInt(dataRow["Id"]),
                            ContentType = Helper.GetDbValue(dataRow["ContentType"]),
                            TargetUrl = Helper.GetDbValue(dataRow["TargetUrl"]),
                            ImageUrl = Helper.GetDbValue(dataRow["ImageUrl"]),
                            ImageAltText = Helper.GetDbValue(dataRow["AltText"]),
                            ImageHeader = Helper.GetDbValue(dataRow["Header"]),
                            Description = Helper.GetDbValue(dataRow["content"]),
                            Sequence = Helper.ConvertToInt(dataRow["Sequence"])
                        };

                        lstContent.Add(content);
                    }
                }
            }

            return lstContent;

        }

        public string CreateImageContent(PreseviDataModel imageContent)
        {
            try
            {
                dataAccess.CreateImageContent(imageContent);
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string EditImageContent(PreseviDataModel imageContent)
        {
            try
            {
                dataAccess.EditImageContent(imageContent);
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteImageContent(PreseviDataModel imageContent)
        {
            try
            {
                dataAccess.DeleteImageContent(imageContent);
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AuthenticateUser(string userName, string password)
        {
            return dataAccess.Authenticate(userName, password);
        }
    }
}