using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication1.Models;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        public IEnumerable<int> GetListOfIds(string s)
        {           
            List<int> _result = s.Split(',').Select(item => int.Parse(item)).ToList();

            return _result;
        }

        [WebMethod]
        public string AddText(string Title, string Lead, string Content, int CategoryId, string Tags)
        {
            string ret = "Dodano tekst";

            try
            {
                Art temp = new Art();
                var context = new Model1();                


                temp.Title = Title;
                temp.Lead = Lead;
                temp.Content = Content;
                temp.CategoryId = CategoryId;
                temp.Tags = Tags;

                context.Art.Add(temp);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                ret = "Ponów akcję: " + e;
            }

            return ret;
        }

        [WebMethod]
        public string EditText(string Title = null, string Lead = null, string Content = null, int CategoryId = -1, string Tags = null)
        {
            string ret = "Edytowano tekst";

            try
            {
                using (var db = new Model1())
                {
                    var temp = db.Art.SingleOrDefault(b => b.Title == Title && b.CategoryId == CategoryId);
                    if (temp != null)
                    {


                        if (Title != null) temp.Title = Title;
                        if (Lead != null) temp.Lead = Lead;
                        if(Context != null) temp.Content = Content;
                        if(CategoryId != -1) temp.CategoryId = CategoryId;
                        if(Tags != null) temp.Tags = Tags;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                ret = "Ponów akcję: " + e;
            }

            return ret;
        }

        [WebMethod]
        public string DeleteText(string Title, int CategoryId)
        {
            string ret = "Usunięto tekst";

            try
            {
                using (var db = new Model1())
                {
                    var result = db.Art.SingleOrDefault(b => b.Title == Title && b.CategoryId == CategoryId);
                    if (result != null)
                    {
                        db.Art.Remove(result);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                ret = "Ponów akcję: " + e;
            }

            return ret;
        }

        [WebMethod]
        public string PublishText(string Title, int CategoryId)
        {
            string ret = "Wysłano tekst";

            try
            {
                using (var db = new Model1())
                {
                    var result = db.Art.SingleOrDefault(b => b.Title == Title && b.CategoryId == CategoryId);
                    if (result != null)
                    {
                        result.IsPublish = 1;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                ret = "Ponów akcję: " + e;
            }

            return ret;
        }
    }
}
